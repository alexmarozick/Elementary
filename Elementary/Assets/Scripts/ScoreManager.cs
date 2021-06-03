using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// credit: https://www.youtube.com/watch?v=YUcvy9PHeXs&t=113s

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    public int Score = 0;

    void Awake ()   
        {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
}
