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
using Tegridy.Tools;
namespace Tegridy.Cam
{
    public class TegridyCamRig : MonoBehaviour
    {
        [Header("Modes")]
        public bool follow; //allow follow cam 
        public bool pivot; //allow pivot cam
        public bool rts; //allow rts cam

        [Header("World Objects")]
        public GameObject target; //target for the camera to track
        public CameraObject camRig; //the world objects that contain the cameraa

        [Header("Camera Settings")]
        public FollowConfig[] followSettings; //settings for the scripts / modes
        public PivotConfig[] pivotSettings;
        public RTSConfig[] rtsSettings;
        public CameraConfig[] cameraSettings;
        public bool disableCam = true;

        int mode = 0; //1 = Top Down || 2 = Thirdperson || 3 = First Person || 4 = Transition
        int camConfig = 0; //keep track of the config we are using
        int followConfig = 0; //keep track of the follow cam config
        int pivotConfig = 0; //keep track of the picot cam config
        int rtsConfig = 0; //keep track of the  rtsconfig we are using

        //camera scripts & input
        TegridyCamPivot pivotCam;
        TegridyCamFollow followCam;
        TegridyCamRTS rtsCam;

        [HideInInspector] public camInput input;
        public void StartUp()
        {
            pivotCam = new TegridyCamPivot();
            followCam = new TegridyCamFollow();
            rtsCam = new TegridyCamRTS();
            mode = 0;
        }
        private void LateUpdate()
        {
            //Use the selected method and move the cam
            switch (mode)
            {
                case 3:
                    rtsCam.MoveCam();
                    break;
                case 2:
                    pivotCam.MoveCam();
                    break;
                case 1:
                    followCam.MoveCam();
                    break;
            }
            input = new camInput();
        }

        #region Control
        public void nextMode()
        {
            mode++;
            if (mode > 3) mode = 1;
            ChangeMode(mode);
        }
        public void ResetMode()
        {
            ChangeMode(mode);
        }
        public void ChangeMode(int selectedMode)
        {
            camRig.cam.enabled = true;
            mode = selectedMode;
            switch (mode)
            {
                case 3:
                    RTSCam();
                    break;
                case 2:
                    PivotCam();
                    break;
                case 1:
                    FollowCam();
                    break;
                case 0:
                    if(disableCam) camRig.cam.enabled = false;
                    break;
            }
        }
        public void NextCameraConfig()
        {
            Debug.Log("Next Camera Config");
            camConfig++;
            if (camConfig >= cameraSettings.Length) camConfig = 0;
            SetCameraConfig(camConfig);
        }
        public void SetCameraConfig(int setting)
        {
            camConfig = setting;
            //camRig.cam.fieldOfView = cameraSettings[setting].fieldOfView;
            Debug.Log("Set cam settings");

        }
        public void SetCamera(CameraSetup settings)
        {
            //decide what camera we are using and set the settings variable for later
            // 0 = no controller || 1 = Follow Cam || 2 = Pivot Cam 
            switch (settings.mode)
            {
                case 1:
                    followConfig = settings.modeConfig;
                    break;
                case 2:
                    pivotConfig = settings.modeConfig;
                    break;
                case 3:
                    rtsConfig = settings.modeConfig;
                    break;
            }
            //load the new camer settings and change the camera
            ChangeMode(settings.mode);
        }
        public void NextModeConfig()
        {
            Debug.Log("Next Mode config for mode " + mode);
            switch (mode)
            {
                case 1:
                    ChangeFollowConfig();
                    break;
                case 2:
                    ChangePivotConfig();
                    break;
            }
        }
        #endregion

        #region FollowCam
        public void FollowCam()
        {
            if (follow)
            {
                SetCameraConfig(followSettings[followConfig].camConfig);
                ResetTransforms();
                followCam.StartUp(this, followSettings[followConfig]);
                mode = 1;
            }
            else nextMode();
        }
        public void ChangeFollowConfig()
        {
            followConfig++;
            if (followConfig >= followSettings.Length) followConfig = 0;
            FollowCam();
        }
        #endregion
        #region PivotCam
        public void PivotCam()
        {
            if (pivot)
            {
                SetCameraConfig(pivotSettings[pivotConfig].camConfig);
                ResetTransforms();
                pivotCam.StartUp(this, pivotSettings[pivotConfig]);
                mode = 2;
            }
            else nextMode();
        }
        public void ChangePivotConfig()
        {
            pivotConfig++;
            if (pivotConfig >= pivotSettings.Length) pivotConfig = 0;
            PivotCam();
        }
        #endregion
        public void RTSCam()
        {
            if (rts)
            {
                SetCameraConfig(rtsSettings[rtsConfig].camConfig);
                ResetTransforms();
                rtsCam.StartUp(this, rtsSettings[rtsConfig]);
                mode = 3;
            }
            else nextMode();
        }

        private void ResetTransforms()
        {
            TransformTools.SetZero(camRig.main);
            TransformTools.SetZero(camRig.pivot);
            TransformTools.SetZero(camRig.camHolder);
        }

    }
}