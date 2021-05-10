using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Fields

    protected float destroyPoints;

    protected float percentageSpawn;

    protected PickupEffect effect;

    #endregion

    #region Properties

    public PickupEffect Effect
    {
        get { return effect; }
    }

    #endregion

    #region Methods





    /// <summary>
    /// When a collision happens with a ball, add points and destroy this block
    /// </summary>
    /// <param name="col"></param>
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
