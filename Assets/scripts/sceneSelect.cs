using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSelect : MonoBehaviour {
    public int door;
    public static bool door1 = false;
    public static bool door2 = false;
    public static bool door3 = false;

    void OnTriggerEnter(Collider other)
    {
        if(door == 1)
        {
            door1 = true;
            SceneManager.LoadScene("prototype");
            Debug.Log("#1");
        }
        else
        {
            door1 = false;
        }
        if(door == 2)
        {
            door2 = true;
            SceneManager.LoadScene("prototype");
            Debug.Log("#2");
        }
        else
        {
            door2 = false;
        }
        if(door == 3)
        {
            door3 = true;
            SceneManager.LoadScene("prototype");
            Debug.Log("#3");
        }
        else
        {
            door3 = false;
        }
    }
}
