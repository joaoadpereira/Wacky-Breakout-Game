using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles Paddle gameObject
/// </summary>
public class Paddle : MonoBehaviour
{
    #region Fields

    [SerializeField] float controllerSpeed=2;

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

        if (horizontalInput > 0 && isOutRight == false)
        {
            positionX += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
        }
        else if (horizontalInput < 0 && isOutLeft == false)
        {
            positionX += horizontalInput * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
        }

        transform.position = new Vector2(positionX, transform.position.y);

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

            if (ballScript.IsBeginning == false)
            {
                ballScript.SetDirection(direction);
            }

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
    #endregion
}
