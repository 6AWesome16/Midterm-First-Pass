using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseandStart : MonoBehaviour {
    public Text Pause;
    public AudioSource myAudio;
    void Start () {
        Time.timeScale = 0f;
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
	}
}
