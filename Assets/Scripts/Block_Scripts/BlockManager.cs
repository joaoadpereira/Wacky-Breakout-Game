using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    #region Fields
    
    //points variable definition
    static float points;

    //Number of blocks definition
    [SerializeField] int currentNumberOfBlocks;
    SpawnBlocks spawnBlocks;

    bool gameOver = false;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current number of points 
    /// </summary>
    public float Points
    {
        get { return points; }
    }

    #endregion

    #region Methods

    private void Start()
    {
        EventManager.AddPointsListener(AddPoints);

        //initial number of blocks instantiated
        spawnBlocks = GetComponent<SpawnBlocks>();
        currentNumberOfBlocks = spawnBlocks.NumberOfBlocksInGame;

        //register as block reduce blocks left event
        EventManager.AddReduceBlockListener(ReduceBlockFromCurrentNumberOfBlocks);
    }

    private void Update()
    {
        if (currentNumberOfBlocks < 1 && !gameOver)
        {
            MenuManager.GotoMenu(MenuName.GameOverMenu);
            gameOver = true;
        }
    }

    /// <summary>
    /// Adds the 'PointsToAdd' to points variable 
    /// </summary>
    /// <param name="PointsToAdd"></param>
    public void AddPoints(int PointsToAdd)
    {
        points += (float)PointsToAdd;
    }

    /// <summary>
    /// Reduces 1 block to the current number of blocks 
    /// </summary>
    public void ReduceBlockFromCurrentNumberOfBlocks()
    {
        currentNumberOfBlocks -= 1;
    }

    #endregion

}
