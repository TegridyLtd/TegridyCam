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

public class TegridyCamRigControlOld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	/*
    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(1))
		{
			float dx = (Input.mousePosition.x - inst_mouse_position.x) / Screen.width;
			float dy = (Input.mousePosition.y - inst_mouse_position.y) / Screen.height;
			transform.eulerAngles += new Vector3(Mathf.Clamp(dy, -2f, 2f) * -200f * Time.deltaTime, Mathf.Clamp(dx, -2f, 2f) * 200f * Time.deltaTime, 0f) * cam_rotate_speed;
		}

		inst_mouse_position = Input.mousePosition;

		Vector3 cam_pos = transform.position;
		if (Input.GetAxis("Mouse ScrollWheel") != 0f)
			cam_pos.y -= Time.deltaTime * cam_scope_speed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel"));
		if (Input.GetKey(KeyCode.LeftArrow))
			cam_pos -= Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * Time.deltaTime * cam_pan_speed;
		if (Input.GetKey(KeyCode.RightArrow))
			cam_pos += Vector3.ProjectOnPlane(transform.right, Vector3.up).normalized * Time.deltaTime * cam_pan_speed;
		if (Input.GetKey(KeyCode.UpArrow))
			cam_pos += Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * Time.deltaTime * cam_pan_speed;
		if (Input.GetKey(KeyCode.DownArrow))
			cam_pos -= Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized * Time.deltaTime * cam_pan_speed;
		transform.position = cam_pos;
	}*/
}
