using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseandStart : MonoBehaviour {
    public Text Pause;
    public Text myText;
    public AudioSource myAudio;
    void Start () {
        Time.timeScale = 0f;
        myText = GameObject.Find("Score").GetComponent<Text>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Time.timeScale = 1f;
            Pause.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            Time.timeScale = 0f;
            Pause.enabled = true;
            myAudio.Play();
        }
        if (Pause.enabled)
        {
            myText.text = "Press R to start over!\n";
            myText.text += "Press M to go back to level select!";
            if(SceneManager.GetActiveScene().buildIndex == 0)
            {
                myText.text = "";               
            }
        }
        
        if (Input.GetKey(KeyCode.R) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKey(KeyCode.M) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
