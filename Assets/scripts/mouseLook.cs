using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {
    public float mouseSensitivty;
    float verticalLookAngle = 0f;
	//you can make a sensitivity thing for both axes, we won't right now tho
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivty;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivty;
        //apply rotations to the camera transform

        //rotates camera
        //transform.Rotate(-mouseY, mouseX, 0);

        //rotates the parent cube instead of the camera
        //transform.Rotate(-mouseY, 0f, 0f);
        transform.parent.Rotate(0f, mouseX, 0f);

        verticalLookAngle -= mouseY;
        verticalLookAngle = Mathf.Clamp(verticalLookAngle, -89f, 89f);//don't let player look straight up
        //correction pass: unroll the camera
        //transform.localEulerAngles.z = 0f;
        transform.localEulerAngles = new Vector3(
            verticalLookAngle,
            transform.localEulerAngles.y,//replaced transform.localEularAngles.c with vertical look, overriding z angle with zero
            0f);
        //fuck you robert and your craaaaaaazy choices
        //lock the mouse cursor and hide it for greater immersion
        if (Input.GetMouseButtonDown( 0 ))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
