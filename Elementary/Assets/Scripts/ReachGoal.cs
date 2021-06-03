using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachGoal : MonoBehaviour
{
    public Transform player;
    public GameObject terrain;
    bool connected;
    public ResultScreen victoryscreen;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume=0.5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            connected = true;
            audioSource.PlayOneShot(clip, volume);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            connected = false;
        }
    }

    void Update()
    {
        if (connected)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    victoryscreen.Setup(100);
                }
            }
        }
    }
}
