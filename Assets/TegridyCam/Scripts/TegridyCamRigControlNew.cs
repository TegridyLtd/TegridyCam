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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tegridy.Cam
{
    public class TegridyCamRigControlNew : MonoBehaviour
    {
        public TegridyCamRig cameraRig;
        NewControls playerInput;

        private void Awake()
        {
            playerInput = new NewControls();
            playerInput.Enable();
            cameraRig.StartUp();
        }
        private void Update()
        {
            if (playerInput.Camera.ChangeCamConfig.triggered) cameraRig.NextCameraConfig();
            if (playerInput.Camera.ChangeMode.triggered) cameraRig.nextMode();
            if (playerInput.Camera.ChangeModeConfig.triggered) cameraRig.NextModeConfig();

            //send the player input to the current controller
            camInput input = new camInput();
            input.horizontal = playerInput.Camera.Look.ReadValue<Vector2>().y;
            input.vertical = playerInput.Camera.Look.ReadValue<Vector2>().x;
            input.zoom = playerInput.Camera.CamZoom.ReadValue<Vector2>().y;
            input.moveX = playerInput.Camera.Move.ReadValue<Vector2>().x;
            input.moveZ = playerInput.Camera.Move.ReadValue<Vector2>().y;
            input.rotate = playerInput.Camera.Rotate.ReadValue<float>();
            cameraRig.input = input;
        }

    }
}