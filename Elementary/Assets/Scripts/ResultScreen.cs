using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// credit: Coco Code Creare great GAME OVER screen in Unity UI - Unity Tutorial
// https://www.youtube.com/watch?v=K4uOjb5p3Io

public class ResultScreen : MonoBehaviour
{
    public Text pointsText;
    public string scene;

    public GameObject ScoreScreen;

    public void Setup(int score) {
        // GameObject ScoreScreen = GameObject.Find("Score");
        
        ScoreScreen.SetActive(false);
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";    
    }

    public void RestartButton() {
        SceneManager.LoadScene(scene);
    }

    public void ExitButton() {
        SceneManager.LoadScene("MainMenu");
    }
}
