using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour {
    //assign in inspector
    public AudioSource myAudioSource;
    public AudioClip[] myRandomSounds;
    //[] make an array
    //a set of variables, a list so we can store more than one item in it

	// Update is called once per frame
	void Update () {
        //1. play a sound
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    myAudioSource.Play();//the most basic way to play a sound
        //}
        //2. play it repeatedly
        //if (Input.GetKey(KeyCode.Space) && myAudioSource.isPlaying == false)
        //{
        //    myAudioSource.Play();//the most basic way to play a sound
        //}
        //3. Toggle a sound on and off
        //press space to turn it on, and then press again for off
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myAudioSource.loop = true;//make sure it is loopin
            if (myAudioSource.isPlaying)
            {
                myAudioSource.Stop();//if it is already playing, stop it
            }
            else
            {
                myAudioSource.Play();//if it ain't play that funky music
            }
        }

        //4.Play a random sound
        //if i press spacebar, it plays a random sound
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //will spit out 0, 1, or 2 so long as it is an int
            int randomNumber = Random.Range(0, myRandomSounds.Length);//length measures the length of an array
            myAudioSource.clip = myRandomSounds[randomNumber];
            myAudioSource.Play();
        }
    }
}
