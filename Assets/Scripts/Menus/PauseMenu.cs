using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Pauses and upauses the game. Listens for the OnClick events for the pause menu buttons
/// </summary>
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //pause the game when added to the scene 
        Time.timeScale = 0;
    }

    /// <summary>
    /// Handles the on click event from the resume button
    /// </summary>
    public void HandleResumeButton()
    {
        //unpause game and destroy menu
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    /// <summary>
    /// Handles the on click event from the quit button in the gameplay scene 
    /// </summary>
    public void HandleQuitButtonGamePlay()
    {
        //unpause game, destroy menu and go to main menu
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GotoMenu(MenuName.MainMenu);

    }
}
