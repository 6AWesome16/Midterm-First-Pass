using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbodyvelocity : MonoBehaviour {
    Vector3 inputVector; //take input from update and send it into FixedUpdate for physics

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //grab input for this frame
        float horizontalInput = Input.GetAxis("Horizontal");//corresponds to A and D or arrows
        float verticalInput = Input.GetAxis("Vertical");//correspondes to W and S or arrows
        //transform our input values based on this transform "right"/"forward" directions
        inputVector = transform.right * horizontalInput + transform.forward * verticalInput;

        //normalize the inputvector so the diagonal movement isnt faster
        if(inputVector.magnitude > 1f)
        {
            inputVector = Vector3.Normalize(inputVector);
        }

	}
    //called once per physics frame
    void FixedUpdate()
    {
        //if (inputVector.magnitude > 0.001f)
        //{
            GetComponent<Rigidbody>().velocity = inputVector * 10f + Physics.gravity * 0.2f;
        //this is good for movement
        //AddForce is good for cars and shit
        //}
    }
}
