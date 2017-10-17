using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ratManager : MonoBehaviour {
    public ratmovement ratPrefab;
    public Transform ratParent;

    //the move variables ensure the rats are centered on the track
    public float moveRight;
    public float moveBack;
    
    //determines number of rats
    float tracks = 2f;
    float ratsPerTrack = 6f;
    public static float totalRats;

    //accounts for the spacing between the rats
    public float spacingX;
    public float spacingY;

    void Start () {
        ratParent = GameObject.Find("rats").transform;
        totalRats = ratsPerTrack * tracks;

        //change gridY based on the round
        //round contained by scenemanager index
        //if scene number is 1, base number of rats
        //if more, increase grid Y
        for(int y = 0; y < ratsPerTrack; y++)
        {
            for(int x = 0; x < tracks; x++)
            {
                //mess with the y so that the rats are evenly spaced across the entirety of the tracks

                Vector3 pos = new Vector3((x - moveRight) * spacingX, 0 , (y - moveBack) * spacingY);
                //instantiates one rat @ 0,0,0 with rotation 0,0,0
                Instantiate(ratPrefab, pos, Quaternion.Euler(0, 0, 0), ratParent);
            }
        }
	}
	
	void Update () {
		
	}
}
