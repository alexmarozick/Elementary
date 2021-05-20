using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Use this for initialization
    public float distance;
    public Transform Player;
 
    void Update () {
 
        // transform.position = transform.forward * distance + Player.position;
 
        // if (Input.GetKey (KeyCode.E)) {
 
        //     transform.RotateAround (Player.position, Vector3.up, 90);
            
        //     // will slowly rotate y
        //     //transform.RotateAround (Player.position, Vector3.up, 90 * Time.deltaTime);

        // }
    }
 
    void FixedUpdate ()
    {
        // if you want a angle on your camera
   
 
        if (Input.GetKey (KeyCode.E)) {
 
            transform.RotateAround (Player.position, Vector3.up, 90);
            
            // will slowly rotate y
            //transform.RotateAround (Player.position, Vector3.up, 90 * Time.deltaTime);

        }
    }
}
