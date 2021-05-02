using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Fields

    protected float destroyPoints;

    protected float percentageSpawn;

    #endregion

    #region Methods

    virtual protected void Start()
    {

    }

    ///// <summary>
    ///// Function to handle the impact of block with ball
    ///// </summary>
    //virtual protected void HandleBlockBallImpact()
    //{
    //    //Add 'destroyPoints' from global points 
    //    BlockManager.AddPoints(destroyPoints);

    //    //Destroy this block
    //    Destroy(gameObject);
    //}

 
    public virtual void ActionBlock()
    {
        //some code
    }


    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            //Add 'destroyPoints' from global points 
            BlockManager.AddPoints(destroyPoints);

            //Destroy this block
            Destroy(gameObject);
        }
    }

    #endregion
}
