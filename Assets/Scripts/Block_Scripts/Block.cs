using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    #region Fields

    protected float destroyPoints;

    protected float percentageSpawn;

    protected PickupEffect effect;

    //support Add points event
    PointsAddedEvent pointsAddedEvent;

    //support reduce blocks left event
    ReduceBlocksLeftEvent reduceBlocksLeftEvent;


    #endregion

    #region Properties

    public PickupEffect Effect
    {
        get { return effect; }
    }

    /// <summary>
    /// Exposes the destroyPoints of this block
    /// </summary>
    public float DestroyPoints
    {
        get { return destroyPoints; }
    }

    #endregion

    #region Methods

    virtual protected void Start()
    {
        //add points event handling
        pointsAddedEvent = new PointsAddedEvent();

        //register as invoker to add points event
        EventManager.AddPointsInvoker(this);

        //add reduce blocks left event
        reduceBlocksLeftEvent = new ReduceBlocksLeftEvent();
        EventManager.AddReduceBlockInvoker(this);
    }



    /// <summary>
    /// When a collision happens with a ball, add points and destroy this block
    /// </summary>
    /// <param name="col"></param>
    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            //Add 'destroyPoints' from global points 
            pointsAddedEvent.Invoke((int)destroyPoints);
            
            //Invoke reduce number of blcoks
            reduceBlocksLeftEvent.Invoke();

            //Destroy this block
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Adds the given listener for the add points event
    /// </summary>
    /// <param name="listener"></param>
    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAddedEvent.AddListener(listener);
    }

    /// <summary>
    /// ADds the given listener to the reduce blocks left event
    /// </summary>
    /// <param name="listener"></param>
    public void AddReduceBlocksLeftListener(UnityAction listener)
    {
        reduceBlocksLeftEvent.AddListener(listener);
    }

    #endregion
}
