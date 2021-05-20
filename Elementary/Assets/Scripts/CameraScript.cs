using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Use this for initialization
    public float distance;
    public Transform Player;
 
    void Update () {
 
        if (Input.GetKeyDown (KeyCode.E)) {
 
            transform.RotateAround (Player.position, Vector3.up, 90);

            //TODO change player orientation/input so it works with camera and player doesnt get disoriented

        }
    }
 
}
