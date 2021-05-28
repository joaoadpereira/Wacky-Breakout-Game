using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    #region Fields
    
    //points variable definition
    static float points;

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
    }

    /// <summary>
    /// Adds the 'PointsToAdd' to points variable 
    /// </summary>
    /// <param name="PointsToAdd"></param>
    public void AddPoints(int PointsToAdd)
    {
        points += (float)PointsToAdd;
    }

    #endregion

}
