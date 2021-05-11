using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// credit: Coco Code Creare great GAME OVER screen in Unity UI - Unity Tutorial
// https://www.youtube.com/watch?v=K4uOjb5p3Io

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton() {
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitButton() {
        // TODO create the MainMenu Scene
        // SceneManager.LoadScene("MainMenu");
    }
}
