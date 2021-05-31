using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    #region Fields

    //define text fields
    [SerializeField] TMP_Text textNumberBalls;
    int numberOfBalls;

    [SerializeField] TMP_Text textPoints;
    float points = 0;

    //support block 
    [SerializeField] BlockManager blockManager;

    //support Ball utilis
    [SerializeField] BallUtils ballUtils;

    //support last ball lost event
    LastBallLostEvent lastBallLostEvent = new LastBallLostEvent();
    bool gameOver = false;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the current points
    /// </summary>
    public float Points
    {
        get { return points; }
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        //register this object as invoker to last ball lost event 
        EventManager.LastBallLostInvoker(this);
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

        //invoke last ball lost event case number of balls <1
        if (numberOfBalls <=0 && !gameOver)
        {
            lastBallLostEvent.Invoke();
            gameOver = true;
        }
    }

    /// <summary>
    /// Adds the given listener to the last ball lost event listener
    /// </summary>
    /// <param name="listener"></param>
    public void AddLastBallLostListener(UnityAction listener)
    {
        lastBallLostEvent.AddListener(listener);
    }

    #endregion
}
