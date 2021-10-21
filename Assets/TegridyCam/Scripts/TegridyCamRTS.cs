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
	public class TegridyCamRTS
	{
		TegridyCamRig control;
		RTSConfig config;
		public void StartUp(TegridyCamRig thisControl, RTSConfig thisConfig)
        {
			control = thisControl;
			config = thisConfig;

			control.camRig.main.transform.position = config.offsetPos;
			control.camRig.main.transform.eulerAngles = config.offsetRot;
		}
		
		public void MoveCam()
		{
			Vector3 cam_pos = control.camRig.main.transform.position;
			Vector3 newRot = control.camRig.pivot.transform.eulerAngles;

			if (config.zoom)
			{
				cam_pos.y += (control.input.zoom / 1000) * config.zoomSpeed;
				cam_pos.y = Mathf.Clamp(cam_pos.y, config.zoomMin, config.zoomMax);
			}
			if (config.pan)
			{
				float panAmmount = Time.deltaTime * config.panSpeed;
				if (control.input.moveX < 0) cam_pos.x -= panAmmount;
				else if (control.input.moveX > 0) cam_pos.x += panAmmount;

				if (control.input.moveZ > 0) cam_pos.z += panAmmount;
				else if (control.input.moveZ < 0) cam_pos.z -= panAmmount;

				if(config.panMax)
                {
					cam_pos.z = Mathf.Clamp(cam_pos.z, -config.panMaxZ, config.panMaxZ);
					cam_pos.x = Mathf.Clamp(cam_pos.x, -config.panMaxX, config.panMaxX);
				}	
			}
            if (config.rotate) 
			{
				float rotateAmmount = Time.deltaTime * config.rotateSpeed;
				if (control.input.rotate > 0) newRot.y -= rotateAmmount;
				else if (control.input.rotate < 0) newRot.y += rotateAmmount;
			}
			if (config.lookAt)
			{
				Vector3 lookat = Quaternion.LookRotation((control.target.transform.position - control.camRig.main.transform.position), Vector3.up).eulerAngles;
				if (config.lookAtX) newRot.x = lookat.x;
				if (config.lookAtY) newRot.y = lookat.y;
				if (config.lookAtZ) newRot.z = lookat.z;
			}
			control.camRig.main.transform.position = cam_pos;
			control.camRig.pivot.transform.eulerAngles = newRot;
		}
	}
}



