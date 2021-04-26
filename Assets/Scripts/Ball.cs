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

        //add initial movement
        float angleDegreesInitial = -90;
        float angleRadsinitial = Mathf.Deg2Rad * angleDegreesInitial;
        Vector2 direction = new Vector2();
        direction.x = Mathf.Cos(angleRadsinitial);
        direction.y = Mathf.Sin(angleRadsinitial);
        rB2D.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Force);
        
    }

    /// <summary>
    /// Handles when impact occurs with a block 
    /// </summary>
    /// <param name="col"></param>
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Block"))
        {
            Destroy(col.gameObject);
        }
    }

    /// <summary>
    /// Defines the direction of the ball based on the newDirection vector parameter
    /// </summary>
    /// <param name="newDirection"></param>
    public void SetDirection(Vector2 newDirection)
    {
        rB2D.velocity = rB2D.velocity.magnitude * newDirection ;
    }

    #endregion
}
