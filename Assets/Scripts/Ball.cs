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

    Vector2 positionBallIni = new Vector2();

    Rigidbody2D rB2D;
    #endregion

    #region Properties

    public bool IsBeginning
    {
        get { return isBeginning; }
    }

    #endregion

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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isBeginning)
        {
            Vector2 paddlePosition = paddle.transform.position;

            //set position of the ball
            positionBallIni.x = paddlePosition.x;
            positionBallIni.y = paddlePosition.y + paddleDimensionY / 2 + radiousBall;

            transform.position = positionBallIni;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isBeginning == true)
        {
            isBeginning = false;
            AddMovement();
        }
    }

    void AddMovement()
    {
        float angleDegreesInitial = 90;
        float angleRadsinitial = (Mathf.PI / 180) * angleDegreesInitial;
        Vector2 direction = new Vector2();
        direction.x = Mathf.Cos(angleRadsinitial);
        direction.y = Mathf.Sin(angleRadsinitial);

        rB2D.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
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


    public void SetDirection(Vector2 newDirection)
    {
        rB2D.velocity = rB2D.velocity.magnitude * newDirection ;
    }
}
