using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// credit: Unity3D - Fall Detection and Moving the Player
// https://www.youtube.com/watch?v=q-u5RHzFgv8&t=102s

public class FallDetect : MonoBehaviour
{
    GameObject player;
    int hasfallen;
    public ResultScreen GameOverScreen;
    //TODO count moves as we go and store in pointTotal
    int pointTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hasfallen = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= .10) {
            hasfallen += 1;
            if (hasfallen == 1) {
                ScoreManager.Instance.Score -= 20;
            }
            GameOverScreen.Setup(ScoreManager.Instance.Score);
        }
    }
}
