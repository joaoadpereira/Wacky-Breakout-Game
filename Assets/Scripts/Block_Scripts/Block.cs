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

    #endregion
}
