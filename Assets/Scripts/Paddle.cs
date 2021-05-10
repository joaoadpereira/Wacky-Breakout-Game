using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles Paddle gameObject
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Fields

    //handle paddle in screen 
    float leftScreenX;
    float rightScreenX;
    float widthSprite;

    //flag to know if padlle is out of the screen
    bool isOutLeft = false; 
    bool isOutRight = false;

    //handling the touch with ball
    const float BounceAngleHalfRange= (30 * Mathf.PI) / 180;
    float halfColliderWidth;

    //handling the effects in paddle
    bool frozenPaddle = false;
    Timer timerFrozenPaddle;
    bool timerFrozenRunning = false;
    float timeAgain;


    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        //get information about this sprite
        Vector2 sizeSprite = gameObject.GetComponent<BoxCollider2D>().size;
        widthSprite = sizeSprite.x/2;

        //get data about screen
        leftScreenX = ScreenUtils.ScreenLeft;
        rightScreenX = ScreenUtils.ScreenRight;

        //handle touch with ball
        halfColliderWidth = widthSprite / 2;

        //set up listener for the freezerEffect
        timerFrozenPaddle = GetComponent<Timer>();
        EventManager.AddFreezeListener(FreezePaddle);
    }

    /// <summary>
    /// Handles the control movement
    /// </summary>
    void FixedUpdate()
    {
        Vector2 position = transform.position;

        //Add keyboard control to paddle
        float positionX = transform.position.x;
        float horizontalInput = Input.GetAxis("PaddleControl");

        //check if paddle shouldn't be frozen 
        if (!frozenPaddle)
        {
            if (horizontalInput > 0 && isOutRight == false)
            {
                positionX += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            }
            else if (horizontalInput < 0 && isOutLeft == false)
            {
                positionX += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            }

            transform.position = new Vector2(positionX, transform.position.y);
        }
        //Keep paddle in screen
        if (position.x - widthSprite < leftScreenX)
        {
            isOutLeft = true;
        }
        else
        {
            isOutLeft = false; 
        }

        if(position.x + widthSprite > rightScreenX)
        {
            isOutRight = true;
        }
        else
        {
            isOutRight = false;
        }

    }

    private void Update()
    {
        
        //unfreeze the paddle and stop the freeze timer (once freeze timer is finished)
        if (timerFrozenPaddle.Finished)
        {
            //run again the timer
            if (timerFrozenRunning == true)
            {
                frozenPaddle = true;
                timerFrozenPaddle.Duration = timeAgain;
                timerFrozenPaddle.Run();
                timerFrozenRunning = false;
            }
            else
            {
                //unfreeze the paddle
                frozenPaddle = false;
            }

        }

    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && CollisionPlace(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x - coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter / halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
            
        }
    }

    bool CollisionPlace(Collision2D coll)
     {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        //ContactPoint2D[] contacts = coll.contacts;
        //Debug.Log(contacts.le);

        ContactPoint2D[] contacts = new ContactPoint2D[2];
        int v = coll.GetContacts(contacts);
        
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
     }


    /// <summary>
    /// Handles with Freezer event.
    /// Initiates a freeze timer. If already running and called again, keeps a
    /// flag "running" to communicate that timer is running.
    /// </summary>
    /// <param name="freezeDuration"></param>
    void FreezePaddle(float freezeDuration)
    {
        //timer already running 
        if (timerFrozenPaddle.Running)
        {
            timerFrozenRunning = true;
            timeAgain = freezeDuration;
        }
        else
        {
            //starts the freeze timer and sets the flag frozen
            timerFrozenPaddle.Duration = freezeDuration;
            timerFrozenPaddle.Run();
            frozenPaddle = true;
        }
        
    }

    #endregion
}
