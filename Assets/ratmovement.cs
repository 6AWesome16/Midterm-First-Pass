using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ratmovement : MonoBehaviour {
    int turn = 101;
    float horizontalInput;
    float verticalInput;
    Vector3 inputVector;
    float ratMaxSpeed = 0.8f;
    float ratMinSpeed = 0.3f;
    bool canMove = true;
    Rigidbody ratBody;
    Vector3 cameraToRat;
    public static float ratcounter = 0;
    public Camera cam;
    public bool ratCatch = false;

    void Start () {
        ratBody = this.GetComponent<Rigidbody>();
        cam = Camera.main;
	}
	
	void Update () {
        cameraToRat = this.transform.position - cam.transform.position;

        if (Vector3.Dot(cameraToRat.normalized, cam.transform.forward) > 0.5f)
        {
            if (Vector3.Distance(cam.transform.position, this.transform.position) < 8f)
            {
                Debug.Log("cameraToRat");
                if (Input.GetKey(KeyCode.Space))
                {
                    ratCatch = true;
                    Debug.Log("rat catch");
                    Camera.main.GetComponent<textscript>().ratcounter++;
                    Destroy(this.gameObject);
                }
                else
                {
                    ratCatch = false;
                }
            }
        }

        if (turn > Random.Range(50,100))
        {
            ChangeDirection();
        }
        inputVector = transform.right * horizontalInput + transform.forward * verticalInput;
        if(inputVector.magnitude > 1f)
        {
            inputVector = Vector3.Normalize(inputVector);
        }

	}
    void FixedUpdate()
    {
        if (canMove)
        {
            if(Physics.Raycast(this.transform.position, this.inputVector, 2))
            {
                inputVector *= -1;
            }
            ratBody.velocity = inputVector * 10f + Physics.gravity * 0.3f;
            turn++;
        }
    }
    void ChangeDirection()
    {
        turn = 0;
        float checkTurnA = Random.Range(-1.0f, 1.0f);
        float checkTurnB = Random.Range(-1.0f, 1.0f);
        if(checkTurnA > 0)
        {
            horizontalInput = Random.Range(-ratMaxSpeed, -ratMinSpeed);
        }
        if(checkTurnA < 0)
        {
            horizontalInput = Random.Range(ratMinSpeed, ratMaxSpeed);
        }
        if(checkTurnB > 0)
        {
            verticalInput = Random.Range(-ratMaxSpeed, -ratMinSpeed);
        }
        if(checkTurnB < 0)
        {
            verticalInput = Random.Range(ratMinSpeed, ratMaxSpeed);
        }
    }
}
