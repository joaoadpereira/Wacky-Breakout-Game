using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //register as listener to last ball lost event
        EventManager.LastBallLostListener(GameOverInstantiate);
    }

    // Update is called once per frame
    void Update()
    {
        //pause game on esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GotoMenu(MenuName.PauseMenu);
        }
    }

    /// <summary>
    /// Method listener to last ball lost event
    /// Instantiates game over menu
    /// </summary>
    void GameOverInstantiate()
    {
        MenuManager.GotoMenu(MenuName.GameOverMenu);
    }
}
