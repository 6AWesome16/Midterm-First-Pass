using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {
    public float mouseSensitivty;
    float verticalLookAngle = 0f;
    float shake = 2f;
    float shakeAmount = 0.1f;
    float decreaseFactor = 5f;

    void Update () {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivty;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivty;
        //apply rotations to the camera transform
        //if (GameObject.Find("rats").GetComponentInChildren<ratmovement>().ratCatch)
        if (ratmovement.ratCatch && shake >= 0)//causes the shake to work, but never end
        {
            Camera.main.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
            shakeAmount += .001f;
        }
        else
        {
            shake = 2.0f;
            shakeAmount = .1f;
            ratmovement.ratCatch = false;
            //loops back into the first if
        }
       
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
