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

using UnityEngine;
namespace Tegridy.Cam
{
    [System.Serializable] public class CameraObject //Used to keep track of the physical objects that hold the camera
    {
        public GameObject main;
        public GameObject pivot;
        public GameObject camHolder;
        public Camera cam;
    }
    [System.Serializable] public class FollowConfig //Used to hold different configurations for the FollowCam
    {
        public int camConfig = 0;

        [Header("Look At")]
        public bool lookAt;
        public bool lookAtX;
        public bool lookAtY;
        public bool lookAtZ;

        [Header("Follow Axis")]
        public bool follow;
        public bool followX;
        public bool followY;
        public bool followZ;

        [Header("Rotate With Target")]
        public bool rotate;
        public bool rotateX;
        public bool rotateY;
        public bool rotateZ;

        [Header("Zoom Settings")]
        [Tooltip("0 = Disabled, 1 = X axis, 2 = Y axis, 3 = Z Axis")] 
        public int zoom;
        public float zoomCurrent = 10f;  //Default starting point
        public float zoomSpeed = 2f;  //speed of zoom
        public float zoomMax = 90f;
        public float zoomMin = 2f;

        [Header("Cam Offset")]
        public Vector3 offsetPos;  //Player offset
        public Vector3 offsetRot;
    }
    [System.Serializable] public class PivotConfig //Used to hold different configurations for the PivotCam
    {
        public int camConfig = 0;
        public Vector3 rigPivotOffset;
        public Vector3 rigCamOffset;

        [Header("Movement Config")]
        public float moveSpeed = 1f;                      // How fast the rig will move to keep up with the target's position.
        [Range(0f, 10f)] public float turnSpeed = 1.5f;   // How fast the rig will rotate from user input.
        public float turnSmoothing = 0.0f;                // How much smoothing to apply to the turn input, to reduce mouse-turn jerkiness
        public float tiltMax = 75f;                       // The maximum value of the x axis rotation of the pivot.
        public float tiltMin = 45f;                       // The minimum value of the x axis rotation of the pivot.
        public bool verticalReturn = false;           // set wether or not the vertical axis should auto return
        public bool follow;

        [Header("Wall Clip Config")]
        public bool wallClip;
        public float clipMoveTime = 0.05f;              // time taken to move when avoiding cliping (low value = fast, which it should be)
        public float returnTime = 0.4f;                 // time taken to move back towards desired position, when not clipping (typically should be a higher value than clipMoveTime)
        public float sphereCastRadius = 0.1f;           // the radius of the sphere used to test for object between camera and target
        public bool visualiseInEditor;                  // toggle for visualising the algorithm through lines for the raycast in the editor
        public float closestDistance = 0.5f;            // the closest distance the camera can be from the target
        public bool protecting;    // used for determining if there is an object between the target and the camera
        public string dontClipTag = "Player";           // don't clip against objects with this tag (useful for not clipping against the targeted object)
    }
    [System.Serializable] public class RTSConfig //Used to hold different configurations for the RTSCam
    {
        [Header("Starting Positions")]
        public int camConfig;
        public Vector3 offsetPos;
        public Vector3 offsetRot;

        [Header("Zoom Settings")]
        public bool zoom;
        public float zoomMin = 10f;
        public float zoomMax = 100f;
        public float zoomSpeed = 5f;

        [Header("Pan Settings")]
        public bool pan;
        public float panSpeed = 50f;
        public bool panMax;
        public float panMaxX = 100f;
        public float panMaxZ = 100f;

        [Header ("Rotate Settings")]
        public bool rotate;
        public float rotateSpeed = 30f;

        [Header("Look At")]
        public bool lookAt;
        public bool lookAtX;
        public bool lookAtY;
        public bool lookAtZ;
    }
    [System.Serializable] public class CameraConfig //Used to hold different configurations for the Camera
    {
        //clearflags
        //background
        //cullingmask
        //projection 
        //fov axis
        [Range (1, 180)] public float fieldOfView = 90;
        public bool physicalCamera;
        public float clippingNear;
        public float clippingFar;

        public Rect viewportRect;

        public float depth;
        //render path
        //target texture
        public bool occlusionCulling;
        //hdr
        //msaa
        public bool dynamicResolution;
        //target display

    }
    [System.Serializable] public class CameraSetup //Used by the CamControl to define the cameras that can be selected.
    {
        public int control;
        public int mode;
        public int modeConfig;
    }
    public class CameraPos //Used to return a new camera position
    {
        public bool useQuaternion;
        public Vector3 mainPos = Vector3.zero;
        public Vector3 mainRot = Vector3.zero;

        public Vector3 pivotPos = Vector3.zero;
        public Vector3 pivotRot = Vector3.zero;
    }
    public class camInput
    {
        public float horizontal;
        public float vertical;
        public float zoom;
        public float rotate;
        public float moveX;
        public float moveZ;
    }
}