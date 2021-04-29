using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{

    #region Fields

    [SerializeField] GameObject ball;


    #endregion


    #region Properties



    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        //Add initial ball
        Instantiate(ball, Vector2.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {


    }

    /// <summary>
    /// Instantiates a new ball 
    /// </summary>
    public void InstantiateNewBall(bool reduceNumberOfBalls)
    {
        //Reduce the number of balls available
        if (reduceNumberOfBalls == true)
        {           
            BallUtils.ReduceNumberOfBalls();
        }
        
        //Instantiate a new ball
        Instantiate(ball, Vector2.zero, Quaternion.identity);

        //Debug number of balls
        Debug.Log("Number of balls :" + BallUtils.NumberOfBalls);
    }

    #endregion
}
