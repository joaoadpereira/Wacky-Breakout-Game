using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    #region Fields

    FreezerEffectActivated freezerEffectActivated;

    PickupEffect effectThisBlock;

    float freezeEffectDuration;

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        //check the effect of this block
        effectThisBlock = GetComponent<Block>().Effect;

        //set the freeze duration
        freezeEffectDuration = ConfigurationUtils.FreezerEffectDuration;
        
        //Event handling 
        freezerEffectActivated = new FreezerEffectActivated();

        //add effect invoker if this block is a freezer
        if (effectThisBlock == PickupEffect.Freezer)
        {
            EventManager.AddFreezeInvoker(this);
        }
    }

    /// <summary>
    /// Adds the given listener for the destroy event
    /// </summary>
    /// <param name="listener"></param>
    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEffectActivated.AddListener(listener);
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        //effect of this block is freezer
        if (effectThisBlock == PickupEffect.Freezer)
        {
            freezerEffectActivated.Invoke(freezeEffectDuration);
        }

        base.OnCollisionEnter2D(col);
    }

    #endregion
}
