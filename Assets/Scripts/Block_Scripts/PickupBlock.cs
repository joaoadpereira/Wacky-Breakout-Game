using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    #region Fields

    FreezerEffectActivated freezerEffectActivated;
    SpeedupEffectActivated speedupEffectActivated;

    PickupEffect effectThisBlock;

    float freezeEffectDuration;
    float speedupEffectDuration;

    #endregion

    

    // Start is called before the first frame update
    override protected void Start()
    {
        //check the effect of this block
        effectThisBlock = GetComponent<Block>().Effect;

        //set the effects duration
        freezeEffectDuration = ConfigurationUtils.FreezerEffectDuration;
        speedupEffectDuration = ConfigurationUtils.SpeedupEffectDuration;
        
        //Event handling 
        freezerEffectActivated = new FreezerEffectActivated();
        speedupEffectActivated = new SpeedupEffectActivated();

        //add effect invoker if this block is a freezer/speedup
        if (effectThisBlock == PickupEffect.Freezer)
        {
            EventManager.AddFreezeInvoker(this);
        }
        else if (effectThisBlock == PickupEffect.Speedup)
        {
            EventManager.AddSpeedupInvoker(this);
        }

        //Define here destroy points (since OnCollisionEnter2D is handled in this class)
        //destroyPoints = GetComponent<Block>().DestroyPoints;

        base.Start();
    }

    #region Effects event handling

    /// <summary>
    /// Adds the given listener for the freezer event
    /// </summary>
    /// <param name="listener"></param>
    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener for the speedup event
    /// </summary>
    /// <param name="listener"></param>
    public void AddSpeedupEffectListener(UnityAction<float> listener)
    {
        speedupEffectActivated.AddListener(listener);
    }

    /// <summary>
    /// Adds logic no base OnCollisionEnter2D to handle collisions with Effect blocks
    /// </summary>
    /// <param name="col"></param>
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            //effect of this block is freezer/speedup
            if (effectThisBlock == PickupEffect.Freezer)
            {
                freezerEffectActivated.Invoke(freezeEffectDuration);
            }
            else if (effectThisBlock == PickupEffect.Speedup)
            {
                speedupEffectActivated.Invoke(speedupEffectDuration);
            }

            base.OnCollisionEnter2D(col);
        }
    }

    #endregion

}
