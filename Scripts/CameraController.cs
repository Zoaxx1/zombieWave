using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 11, 0); //this is the "y" position of the cam

    private float limitCamView = 5.8f; //the limit of the cam follow the player before can see outside of the walls
    private float limitCamViewDown = -13.0f;
    private float limitCamViewUp = 7.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}

//Will made to another wave of enemys make the map to more big 
