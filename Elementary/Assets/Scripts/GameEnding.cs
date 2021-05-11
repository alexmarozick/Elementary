using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    GameObject player;
    public VictoryScreen VictoryScreen;
    bool m_IsPlayerAtExit;
    int pointTotal = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(m_IsPlayerAtExit == true) {
            VictoryScreen.Setup(pointTotal);
        }
    }



}
