using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class clockscript : MonoBehaviour
{
    public Text clockText;
    public Text myText;
    public float timeLeft;
    public bool updateTime = true;
    public bool updateScore = true;
    void Start()
    {
        if (sceneSelect.door1)
        {
            timeLeft = 60f;
        }
        else if (sceneSelect.door2)
        {
            timeLeft = 25f;
        }
        else if (sceneSelect.door3)
        {
            timeLeft = 30f;
        }
    }

    void Update()
    {
        if (updateTime)
        {
            timeLeft = timeLeft - Time.deltaTime;
        }

        clockText.text = "Time left: " + timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            updateScore = false;

            if (ratManager.totalRats == 200)
            {
                clockText.text = "You caught " + textscript.ratcounter + " rat(s)!";
            }

            timeLeft = 0f;
            updateTime = false;
        }
    }
}

