using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ratmovement : MonoBehaviour
{
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
    public static bool ratCatch = false;
    float coneOfViewMid = 0.95f;
    float coneOfView;
    public ParticleSystem death;
    public Text crosshair;
    public AudioSource myAudio;

    void Start()
    {
        ratBody = this.GetComponent<Rigidbody>();
        cam = Camera.main;
        death = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Text>();
        myAudio = GameObject.Find("deadsound").GetComponent<AudioSource>();
    }

    void Update()
    {
        cameraToRat = this.transform.position - cam.transform.position;

        coneOfView = coneOfViewMid;

        if (Vector3.Dot(cameraToRat.normalized, cam.transform.forward) > coneOfView)
        {
            if (Vector3.Distance(cam.transform.position, this.transform.position) < 8f)
            {
                crosshair.color = Color.green;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ratCatch = true;
                    Debug.Log("rat catch");
                    textscript.ratcounter++;
                    death.transform.position = this.transform.position;
                    death.Play();
                    myAudio.Play();
                    Destroy(this.gameObject);
                    crosshair.color = Color.red;
                }
            }
            else
            {
                ratCatch = false;
                crosshair.color = Color.red;
            }
        }


        if (turn > Random.Range(50, 100))
        {
            ChangeDirection();
        }
        inputVector = transform.right * horizontalInput + transform.forward * verticalInput;
        if (inputVector.magnitude > 1f)
        {
            inputVector = Vector3.Normalize(inputVector);
        }

    }
    void FixedUpdate()
    {
        if (canMove)
        {
            if (Physics.Raycast(this.transform.position, this.inputVector, 2))
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
        if (checkTurnA > 0)
        {
            horizontalInput = Random.Range(-ratMaxSpeed, -ratMinSpeed);
        }
        if (checkTurnA < 0)
        {
            horizontalInput = Random.Range(ratMinSpeed, ratMaxSpeed);
        }
        if (checkTurnB > 0)
        {
            verticalInput = Random.Range(-ratMaxSpeed, -ratMinSpeed);
        }
        if (checkTurnB < 0)
        {
            verticalInput = Random.Range(ratMinSpeed, ratMaxSpeed);
        }
    }
}
