using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockManager 
{
    #region Fields
    
    //points variable definition
    static float points;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current number of points 
    /// </summary>
    public static float Points
    {
        get { return points; }
    }

    #endregion

    #region

    /// <summary>
    /// Adds the 'PointsToAdd' to points variable 
    /// </summary>
    /// <param name="PointsToAdd"></param>
    public static void AddPoints(float PointsToAdd)
    {
        points += PointsToAdd;
    }

    #endregion

}
