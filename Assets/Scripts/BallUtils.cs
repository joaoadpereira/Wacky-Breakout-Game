using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUtils : MonoBehaviour
{
    #region Fields

    //initial number of balls available
    //float initialNumberOfBalls = ConfigurationUtils.InitialNumberBalls;
    int numberOfBalls;

    #endregion

    #region Properties

    /// <summary>
    /// Provides the current number of balls 
    /// </summary>
    public int NumberOfBalls
    {
        get { return numberOfBalls; }
    }

    #endregion

    #region Methods

    private void Start()
    {
        //register as listener of reduce balls left event
        EventManager.ReduceBallsLeftListener(ReduceNumberOfBalls);

        //convert float balls to int balls
        numberOfBalls = (int)ConfigurationUtils.InitialNumberBalls;

    }

    /// <summary>
    /// Take or add "operation" balls out of total number of balls available 
    /// </summary>
    void ReduceNumberOfBalls(int operation)
    {
        numberOfBalls += operation;
      
    }

    #endregion

}
