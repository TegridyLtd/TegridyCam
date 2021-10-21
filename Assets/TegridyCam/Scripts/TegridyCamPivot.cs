/////////////////////////////////////////////////////////////////////////////
// Copyright (C) 2021 Tegridy Ltd                                          //
// Author: Darren Braviner                                                 //
// Contact: db@tegridygames.co.uk                                          //
/////////////////////////////////////////////////////////////////////////////
//                                                                         //
// This program is free software; you can redistribute it and/or modify    //
// it under the terms of the GNU General Public License as published by    //
// the Free Software Foundation; either version 2 of the License, or       //
// (at your option) any later version.                                     //
//                                                                         //
// This program is distributed in the hope that it will be useful,         //
// but WITHOUT ANY WARRANTY.                                               //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////
//                                                                         //
// You should have received a copy of the GNU General Public License       //
// along with this program; if not, write to the Free Software             //
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,              //
// MA 02110-1301 USA                                                       //
//                                                                         //
/////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using UnityEngine;
namespace Tegridy.Cam
{
    public class TegridyCamPivot
    {
        public TegridyCamRig control;
        public PivotConfig config;

        //Camera Variables
        private float lookAngle;                    // The rig's y axis rotation.
        private float tiltAngle;                    // The pivot's x axis rotation.
        private Vector3 pivotEulers;
        private Quaternion pivotTargetRot;
        private Quaternion transformTargetRot;

        //Wall Clip Variables
        private float m_OriginalDist;             // the original distance to the camera before any modification are made
        private float m_MoveVelocity;             // the velocity at which the camera moved
        private float m_CurrentDist;              // the current distance from the camera to the target
        private Ray m_Ray = new Ray();                        // the ray used in the lateupdate for casting between the camera and the target
        private RaycastHit[] m_Hits;              // the hits between the camera and the target
        private RayHitComparer m_RayHitComparer;  // variable to compare raycast hit distances

        public void StartUp(TegridyCamRig thisControl, PivotConfig thisConfig)
        {
            control = thisControl;
            config = thisConfig;

            control.camRig.pivot.transform.position = config.rigPivotOffset;
            control.camRig.camHolder.transform.position = config.rigCamOffset;

            pivotEulers = control.camRig.pivot.transform.rotation.eulerAngles;
            pivotTargetRot = control.camRig.pivot.transform.rotation;
            transformTargetRot = control.camRig.main.transform.rotation;

            m_OriginalDist = control.camRig.camHolder.transform.localPosition.magnitude;
            m_CurrentDist = m_OriginalDist;

            m_RayHitComparer = new RayHitComparer();
        }
        public void MoveCam()
        {
            if (Time.timeScale < float.Epsilon) return;

            // Get inputs and our time
            float deltaTime = Time.deltaTime;
            float x = control.input.vertical;
            float y = control.input.horizontal;

            // Calculate the speed to turn and rotate the base
            lookAngle += x * config.turnSpeed;
            transformTargetRot = Quaternion.Euler(0f, lookAngle, 0f);

            if (config.verticalReturn) tiltAngle = y > 0 ? Mathf.Lerp(0, -config.tiltMin, y) : Mathf.Lerp(0, config.tiltMax, -y);
            else
            {
                tiltAngle -= y * config.turnSpeed;
                tiltAngle = Mathf.Clamp(tiltAngle, -config.tiltMin, config.tiltMax);
            }
            pivotTargetRot = Quaternion.Euler(tiltAngle, pivotEulers.y, pivotEulers.z);

            if (config.turnSmoothing > 0)
            {
                control.camRig.pivot.transform.localRotation = Quaternion.Slerp(control.camRig.pivot.transform.localRotation, pivotTargetRot, config.turnSmoothing * deltaTime);
                control.camRig.main.transform.localRotation = Quaternion.Slerp(control.camRig.main.transform.localRotation, transformTargetRot, config.turnSmoothing * deltaTime);
            }
            else
            {
                control.camRig.pivot.transform.localRotation = pivotTargetRot;
                control.camRig.main.transform.localRotation = transformTargetRot;
            }
            if (config.follow) control.camRig.main.transform.position = Vector3.Lerp(control.camRig.main.transform.position, control.target.transform.position, deltaTime * config.moveSpeed);
            if (config.wallClip) WallClip();
        }
        private void WallClip()
        {

            // initially set the target distance
            float targetDist = m_OriginalDist;

            m_Ray.origin = control.camRig.pivot.transform.position + control.camRig.pivot.transform.forward * config.sphereCastRadius;
            m_Ray.direction = -control.camRig.pivot.transform.forward;

            // initial check to see if start of spherecast intersects anything
            var cols = Physics.OverlapSphere(m_Ray.origin, config.sphereCastRadius);

            bool initialIntersect = false;
            bool hitSomething = false;

            // loop through all the collisions to check if something we care about
            for (int i = 0; i < cols.Length; i++)
            {
                if ((!cols[i].isTrigger) &&
                    !(cols[i].attachedRigidbody != null && cols[i].attachedRigidbody.CompareTag(config.dontClipTag)))
                {
                    initialIntersect = true;
                    break;
                }
            }

            // if there is a collision
            if (initialIntersect)
            {
                m_Ray.origin += control.camRig.pivot.transform.forward * config.sphereCastRadius;

                // do a raycast and gather all the intersections
                m_Hits = Physics.RaycastAll(m_Ray, m_OriginalDist - config.sphereCastRadius);
            }
            else
            {
                // if there was no collision do a sphere cast to see if there were any other collisions
                m_Hits = Physics.SphereCastAll(m_Ray, config.sphereCastRadius, m_OriginalDist + config.sphereCastRadius);
            }

            // sort the collisions by distance
            Array.Sort(m_Hits, m_RayHitComparer);

            // set the variable used for storing the closest to be as far as possible
            float nearest = Mathf.Infinity;

            // loop through all the collisions
            for (int i = 0; i < m_Hits.Length; i++)
            {
                // only deal with the collision if it was closer than the previous one, not a trigger, and not attached to a rigidbody tagged with the dontClipTag
                if (m_Hits[i].distance < nearest && (!m_Hits[i].collider.isTrigger) &&
                    !(m_Hits[i].collider.attachedRigidbody != null &&
                      m_Hits[i].collider.attachedRigidbody.CompareTag(config.dontClipTag)))
                {
                    // change the nearest collision to latest
                    nearest = m_Hits[i].distance;
                    targetDist = -control.camRig.pivot.transform.InverseTransformPoint(m_Hits[i].point).z;
                    hitSomething = true;
                }
            }

            // visualise the cam clip effect in the editor
            if (hitSomething)
            {
                Debug.DrawRay(m_Ray.origin, -control.camRig.pivot.transform.forward * (targetDist + config.sphereCastRadius), Color.red);
            }

            // hit something so move the camera to a better position
            config.protecting = hitSomething;
            m_CurrentDist = Mathf.SmoothDamp(m_CurrentDist, targetDist, ref m_MoveVelocity,
                                           m_CurrentDist > targetDist ? config.clipMoveTime : config.returnTime);
            m_CurrentDist = Mathf.Clamp(m_CurrentDist, config.closestDistance, m_OriginalDist);

            //is this pivot, main holder or the camera that should be moved?
            control.camRig.camHolder.transform.localPosition = -Vector3.forward * m_CurrentDist;
        }
        public class RayHitComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
            }
        }
    }
}
