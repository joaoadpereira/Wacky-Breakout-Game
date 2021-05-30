using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields

    //flag to define ball in movement or not
    bool isBeginning = true;

    //define paddle
    GameObject paddle;

    //data & positon of ball
    float paddleDimensionY;

    //RigidBody Field
    Rigidbody2D rB2D;

    //reference to ball manager
    BallManager ballManager;

    //Use a timer 
    Timer initialTimer;
    Timer deadTimer;

    //Flag about is moviment or not 
    bool isMoving = false;

    //handling the effects in ball
    Timer speedupEffectTimer;
    bool speedEffect = false;
    Vector2 ballSpeed;


    #endregion

    #region Properties

    public bool IsBeginning
    {
        get { return isBeginning; }
    }

    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        //add initial movement
        rB2D = GetComponent<Rigidbody2D>();

        //get information about paddle
        paddle = GameObject.FindGameObjectWithTag("Paddle");
        paddleDimensionY = paddle.GetComponent<BoxCollider2D>().size.y;

        //Define Ball manager
        ballManager = GameObject.FindGameObjectWithTag("BallManager").GetComponent<BallManager>();

        //Add a timer
        initialTimer = gameObject.AddComponent<Timer>();
        deadTimer = gameObject.AddComponent<Timer>();

        //Setting timer of 1 second
        initialTimer.Duration = 1;
        initialTimer.Run();

        //settiing dead timer 
        deadTimer.Duration = ConfigurationUtils.BallDeadTime; /*RANDOM TIME*/
        deadTimer.Run();

        //setup listener for the speedupEffect
        speedupEffectTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupListener(SpeedupBall);

        //speedup effect support timer
        speedupEffectTimer.AddFinishedTimeListener(SpeedupEffect);

    }

    /// <summary>
    /// Handles with initial movement and destroy ball
    /// </summary>
    private void FixedUpdate()
    {
        //After 1 second and the ball is not moving
        if(initialTimer.Finished && isMoving == false)
        {
            //add initial movement to ball
            AddInitialMovement();
            //change flag
            isMoving = !isMoving;
            
        }

        //Destroys ball after a random time
        if (deadTimer.Finished && isMoving == true)
        {
            //Ball that reached the end of life. So it will not spawn/instantiate a new ball or decrease ball counter(only destroys it self)
            DestroyBall(0,false);
        }

        //Handle if ball leaves the game space
        if(transform.position.y < ScreenUtils.ScreenBottom)
        {
            DestroyBall(-1);
        }
    }

    /// <summary>
    /// Handles with timers update
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// Add initial movement
    /// </summary>
    void AddInitialMovement()
    {
        float angleDegreesInitial = -90;
        float angleRadsinitial = Mathf.Deg2Rad * angleDegreesInitial;
        Vector2 direction = new Vector2();
        direction.x = Mathf.Cos(angleRadsinitial);
        direction.y = Mathf.Sin(angleRadsinitial);

        if (EffectUtils.SpeedupEffectActive)
        {
            SpeedupBall(EffectUtils.TimeLeftSpeedupEffect);
            direction *= 2f;
        }

        rB2D.AddForce(direction * ConfigurationUtils.BallImpulseForce);

    }

    /// <summary>
    /// Increases the speed of the ball within a duration
    /// </summary>
    /// <param name="speedupDuration"></param>
    void SpeedupBall(float speedupDuration)
    {
        
        //check if ball is not with the speedup effect
        if (!speedEffect)
        {
            SetBallSpeed(2f);
            speedEffect = true;

            speedupEffectTimer.Duration = speedupDuration;
            speedupEffectTimer.Run();
        }
        
    }

    /// <summary>
    /// Sets the ball speed based on the given factor 
    /// </summary>
    /// <param name="speedFactor"></param>
    void SetBallSpeed(float speedFactor)
    {
        rB2D.velocity *= speedFactor;
    }


    /// <summary>
    /// Defines the direction of the ball based on the newDirection vector parameter
    /// </summary>
    /// <param name="newDirection"></param>
    public void SetDirection(Vector2 newDirection)
    {
        rB2D.velocity = rB2D.velocity.magnitude * newDirection ;
    }


    /// <summary>
    /// Method is activated when the ball leaves display (bottom)
    /// It adds/removes an "operation" ball
    /// </summary>
    private void DestroyBall(int operation,bool InstantiateNewBall=true)
    {
       //Informs about the ball is out
        ballManager.HandleBallOut(operation,InstantiateNewBall); 

        //Destroy this ball
        Destroy(gameObject);

    }

    /// <summary>
    /// stop speedup effect
    /// </summary>
    public void SpeedupEffect()
    {
        speedupEffectTimer.Stop();
        speedEffect = false;
        SetBallSpeed(0.5f);
    }

    #endregion
}
