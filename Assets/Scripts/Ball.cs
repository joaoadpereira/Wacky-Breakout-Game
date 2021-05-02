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
    float radiousBall;

    //RigidBody Field
    Rigidbody2D rB2D;

    //reference to ball manager
    BallManager ballManager;

    //Use a timer 
    Timer Timer;

    //Flag about is moviment or not 
    bool isMoving = false;

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

        //get info about ball
        radiousBall = GetComponent<CircleCollider2D>().radius;

        //Define Ball manager
        ballManager = GameObject.FindGameObjectWithTag("BallManager").GetComponent<BallManager>();

        //Setting timer of 1 second
        Timer = gameObject.GetComponent<Timer>();
        Timer.Duration = 1;
        Timer.Run();

    }

    private void Update()
    {
        //After 1 second and the ball is not moving
        if(Timer.Finished && isMoving == false)
        {
            //add initial movement to ball
            AddInitialMovement();
            //change flag
            isMoving = !isMoving;
            
        }

        //Destroys ball after a random time
        if (Timer.Finished && isMoving == true)
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
    /// Add initial movement
    /// </summary>
    void AddInitialMovement()
    {
        float angleDegreesInitial = -90;
        float angleRadsinitial = Mathf.Deg2Rad * angleDegreesInitial;
        Vector2 direction = new Vector2();
        direction.x = Mathf.Cos(angleRadsinitial);
        direction.y = Mathf.Sin(angleRadsinitial);
        rB2D.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);

        //Set a Dead Timer with a random time
        if(!Timer.Running)
        {
            Timer.Duration = ConfigurationUtils.BallDeadTime; /*RANDOM TIME*/
            Timer.Run();
        }

    }

    /// <summary>
    /// Handles when impact occurs with a block -> NOT ANYMORE
    /// Impact with blocks are handled within the block 
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.CompareTag("Block"))
        //{
        //    col.gameObject.GetComponent<>().HandleBlockBallImpact();
        //}
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

    #endregion
}
