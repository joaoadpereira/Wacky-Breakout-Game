using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    //support final score display
    HUD HUD;
    string scoreText = "Final Score: ";
    float finalScore;
    [SerializeField] TextMeshProUGUI scoreTextTMPro;

    // Start is called before the first frame update
    void Start()
    {
        //Pause the game when added to the scene
        Time.timeScale = 0;

        //Display actual score  
        HUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        if (HUD != null)
        {
            finalScore = HUD.Points;
        }

        scoreTextTMPro.text = scoreText + finalScore;

        //play gameover clip
        AudioManager.Play(AudioClipName.GameLost);
    }


    /// <summary>
    /// Handles the on click event to the quit button 
    /// </summary>
    public void HandleQuitButtonGameOver()
    {
        //unpause the game, destroy the gameover message and go to main menu
        Time.timeScale = 1;
        MenuManager.GotoMenu(MenuName.MainMenu);
        Destroy(gameObject);
    }
}
