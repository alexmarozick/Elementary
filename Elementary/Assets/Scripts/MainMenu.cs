using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start () {
        if(ScoreManager.Instance != null){
            Destroy(ScoreManager.Instance);
        }
    }
    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame() {
        SceneManager.LoadScene("Level1");
    }
}
