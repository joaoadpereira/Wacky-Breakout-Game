using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    //define text fields
    [SerializeField] TMP_Text textNumberBalls;
    int numberOfBalls=0;

    [SerializeField] TMP_Text textPoints;
    float points = 0;

    //support block 
    [SerializeField] BlockManager blockManager;

    //support Ball utilis
    [SerializeField] BallUtils ballUtils;

    #region Properties

    /// <summary>
    /// Gets the current points
    /// </summary>
    public float Points
    {
        get { return points; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //Update scores
        numberOfBalls = ballUtils.NumberOfBalls;
        points = blockManager.Points;

        //define text fields
        textNumberBalls.text = "Number of balls: " + numberOfBalls.ToString();
        textPoints.text = "Points: " + points;
    }
}
