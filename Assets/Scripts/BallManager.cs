using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallManager : MonoBehaviour
{

    #region Fields

    [SerializeField] GameObject ball;

    Timer InstantiateTimer;

    //Screen Points
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    //flag to retry if spawn zone has overlap
    bool retrySpawn=false;

    //support reduce balls left event
    ReduceBallsLeftEvent reduceBallsLeftEvent;

    #endregion


    #region Properties



    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        //Add initial ball
        GameObject initialBall = Instantiate(ball, Vector2.zero, Quaternion.identity);

        //Add a timer and start it for ball instantiation 
        InstantiateTimer = gameObject.AddComponent<Timer>();
        SetTimer();

        //Define corners of spawn zone rectangle 
        BoxCollider2D collider = initialBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(initialBall.transform.position.x - ballColliderHalfWidth, initialBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(initialBall.transform.position.x + ballColliderHalfWidth, initialBall.transform.position.y + ballColliderHalfHeight);

        //Register as invoker of reduce balls left event 
        reduceBallsLeftEvent = new ReduceBallsLeftEvent();
        EventManager.ReduceBallsLeftInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
        //When the timer (random time) is finished, spawn a new ball
        if (InstantiateTimer.Finished)
        {
            //add a new ball and increase the counter
            HandleBallOut(1,true);
            SetTimer();
        }

        //Check if spawn position is overlaped
        if (retrySpawn)
        {
            SpawnBall();
        }
    }

    /// <summary>
    /// Instantiates a new ball 
    /// </summary>
    /// <param name="operation">Add or take balls from counter</param>
    /// <param name="InstantiateNewBall"></param>
    public void HandleBallOut(int operation,bool InstantiateNewBall)
    {
        //BallUtils.ReduceNumberOfBalls(operation);
        reduceBallsLeftEvent.Invoke(operation);

        //Instantiate a new ball
        if (InstantiateNewBall)
        {
            SpawnBall();
        }
    }

    /// <summary>
    /// Spawns new ball. Takes in consideration if spawn locations is/will overlap. Then waits until possible spawn
    /// </summary>
    void SpawnBall()
    {
        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(ball, Vector2.zero, Quaternion.identity);
        }
        else
        {
            retrySpawn = true;
        }
    }

    /// <summary>
    /// Sets a Timer with random time and runs it 
    /// </summary>
    void SetTimer()
    {
        if (!InstantiateTimer.Running)
        {
            float randomTime = Random.Range(ConfigurationUtils.BallMinSpawnTime, ConfigurationUtils.BallMaxSpawnTime); /*RANDOM MIN & MAX HERE*/
            InstantiateTimer.Duration = randomTime;
            InstantiateTimer.Run();
        }
    }

    /// <summary>
    /// Adds the given listener for the reduce balls left event
    /// </summary>
    /// <param name="listener"></param>
    public void ReduceBallsLeftListener(UnityAction<int> listener)
    {
        reduceBallsLeftEvent.AddListener(listener);
    }

    #endregion
}
