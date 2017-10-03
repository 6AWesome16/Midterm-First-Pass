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
    public Text myText;
    float ratcounter = 0;
    public Camera cam;

    void Start () {
        ratBody = this.GetComponent<Rigidbody>();
	}
	
	void Update () {
        cameraToRat = cam.transform.position - this.transform.position;

        Vector3 screenPos = cam.WorldToScreenPoint(this.gameObject.transform.position);
        //bool onScreen = screenPos.z > 0 && screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1;
        if (Vector3.Dot(cameraToRat, cam.transform.forward) < 0)
        {
            Debug.Log("cameraToRat");
            //if screenpos.x and screenpos.y are withing viewport
            //if (onScreen)
            //if(screenPos.z > 0 && screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1)
            //{
            //Debug.Log("onscreen");
                if (Input.GetKey(KeyCode.Space))
                {
                    ratcounter++;
                    Destroy(this.gameObject);
                }
            //}
        }

        myText.text = "You've caught " + ratcounter + " rat(s)!";

        if (turn > 100)
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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (this.canMove)
            {
                //GameManager.Instance.numCaught++;
                ratBody.velocity = new Vector3(0, 0, 0);
                //GameManager.Instance.numCaught;
                //will move the rat    
                //this.transform.position = moveLocation.transform.position;
            }
        }
    }
}
