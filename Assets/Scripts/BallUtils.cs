using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BallUtils 
{
    #region Fields

    //initial number of balls available
    static int numberOfBalls = 3;

    #endregion

    #region Properties

    /// <summary>
    /// Provides the current number of balls 
    /// </summary>
    public static int NumberOfBalls
    {
        get { return numberOfBalls; }
    }

    #endregion

    #region Methods


    /// <summary>
    /// Take or add "operation" balls out of total number of balls available 
    /// </summary>
    public static void ReduceNumberOfBalls(int operation)
    {
        numberOfBalls += operation;
      
    }

    #endregion

}
