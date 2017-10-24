using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class textscript : MonoBehaviour {
    public Text myText;
    public static int ratcounter = 0;
    public float totalRats;
    Animator trains;
    GameObject ratList;

    void Start() {
        trains = GameObject.Find("Trains").GetComponent<Animator>();
        ratList = GameObject.Find("rats");
    }

    void Update()
    {
        totalRats = ratManager.totalRats;

        myText.text = "You've caught " + ratcounter + " rat(s)!";
        if (Camera.main.GetComponent<clockscript>().timeLeft > 0.3f)
        {
            if (ratcounter == totalRats)
            {
                trains.SetBool("traintime", true);
                Camera.main.GetComponent<clockscript>().updateTime = false;
                myText.text = "You caught all the rats! You Won!";
                myText.text += "\nPress R to try again!";
                myText.text += "\nOr press M to go back to \nthe level select!";
                Destroy(ratList);
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("prototype");
                }
                else if (Input.GetKey(KeyCode.M))
                {
                    SceneManager.LoadScene("psuedoMenu");
                }
            }      
        }
        else
        {
            trains.SetBool("traintime", true);
            myText.text = "You couldn't save all the rats!";
            myText.text += "\nPress R to try again!";
            myText.text += "\nOr press M to go back to \nthe level select!";

            Destroy(ratList);
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("prototype");
            }
            else if (Input.GetKey(KeyCode.M))
            {
                SceneManager.LoadScene("psuedoMenu");
            }
        } 
    }
}