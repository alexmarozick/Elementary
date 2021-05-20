using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{

    public Transform Camera;
    // private Vector3 offset;
    public float lightDistance = 10.0f;


    // Start is called before the first frame update
    void Start () {
        // offset = transform.position - Camera.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = Camera.transform.position + offset;
        transform.position = Camera.transform.position - Camera.transform.forward * lightDistance;
        transform.LookAt (Camera.transform.position);
        transform.position = new Vector3 (transform.position.x, transform.position.y + 5, transform.position.z);
    }
}
