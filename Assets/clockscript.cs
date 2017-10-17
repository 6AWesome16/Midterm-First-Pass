using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clockscript : MonoBehaviour {
    public Text clockText;
    public float timeLeft;
    public bool updateTime = true;

    void Update () {
        if (updateTime)
        {
            timeLeft = timeLeft - Time.deltaTime;
        }
            clockText.text = "Time left: " + timeLeft.ToString("F1");
            if (timeLeft <= 0f)
            {
                timeLeft = 0f;
                updateTime = false;
            }
        }
    }

