using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// credit: https://www.youtube.com/watch?v=YUcvy9PHeXs&t=113s

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint(){
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }

    public int returnPoint() {
        return score;
    }
}
