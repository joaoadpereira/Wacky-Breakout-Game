using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  static class EventManager 
{
    #region Fields
    //event freeze effect support
    static PickupBlock freezeInvoker;
    static UnityAction<float> freezeListener;

    //event speedup effect support
    static List<PickupBlock> speedupInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> speedupListeners = new List<UnityAction<float>>();

    //event add points support
    static Block addPointsInvoker;
    static UnityAction<int> addPointsListener;

    //event reduce balls left support
    static BallManager reduceBallsLeftInvoker;
    static UnityAction<int> reduceBallsLeftListener;

    //event last ball lost event support
    static HUD lastBallLostInvoker;
    static UnityAction lastBallLostListener;

    //event reduce blocks left event
    static List<Block> reduceBlockLeftInvokers = new List<Block>();
    static List<UnityAction> reduceBlockLeftListeners = new List<UnityAction>();

    #endregion

    #region Effects event handling

    /// <summary>
    /// Adds the invoker for the freeze event
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddFreezeInvoker(PickupBlock invoker)
    {
        freezeInvoker = invoker;
        if (freezeListener != null)
        {
            freezeInvoker.AddFreezerEffectListener(freezeListener);
        }
    }

    /// <summary>
    /// Adds the listener for the freeze event 
    /// </summary>
    /// <param name="listener"></param>
    public static void AddFreezeListener(UnityAction<float> listener)
    {
        freezeListener = listener;
        if (freezeInvoker != null)
        {
            freezeInvoker.AddFreezerEffectListener(freezeListener);
        }
    }

    /// <summary>
    /// Adds the invoker for the speedup event
    /// </summary>
    /// <param name="invoker"></param>
   public static void AddSpeedupInvoker(PickupBlock invoker)
   {
        speedupInvokers.Add(invoker);
        foreach(UnityAction<float> listener in speedupListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
   }

   /// <summary>
   /// Adds the listener for the speedup event
   /// </summary>
   /// <param name="listener"></param>
    public static void AddSpeedupListener(UnityAction<float> listener)
    {
        speedupListeners.Add(listener);
        foreach(PickupBlock invoker in speedupInvokers)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    #endregion

    #region Add Points event handling
    /// <summary>
    /// Adds the invoker to the add points event
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddPointsInvoker(Block invoker)
    {
        addPointsInvoker = invoker;
        if (addPointsListener != null)
        {
            addPointsInvoker.AddPointsAddedListener(addPointsListener);
        }
    }

    /// <summary>
    /// Adds the listener to the add points event
    /// </summary>
    /// <param name="listener"></param>
    public static void AddPointsListener(UnityAction<int> listener)
    {
        addPointsListener = listener;
        if (addPointsInvoker != null)
        {
            addPointsInvoker.AddPointsAddedListener(addPointsListener);
        }
    }

    #endregion

    #region Reduce Balls Left event handling

    /// <summary>
    /// Adds the invoker to the reduce ball left event
    /// </summary>
    /// <param name="invoker"></param>
    public static void ReduceBallsLeftInvoker(BallManager invoker)
    {
        reduceBallsLeftInvoker = invoker;
        if (reduceBallsLeftListener != null)
        {
            reduceBallsLeftInvoker.ReduceBallsLeftListener(reduceBallsLeftListener);
        }
    }

    /// <summary>
    /// Adds the listener to the reduce ball left event
    /// </summary>
    /// <param name="listener"></param>
    public static void ReduceBallsLeftListener(UnityAction<int> listener)
    {
        reduceBallsLeftListener = listener;
        if (reduceBallsLeftInvoker != null)
        {
            reduceBallsLeftInvoker.ReduceBallsLeftListener(reduceBallsLeftListener);
        }
    }

    #endregion

    #region Last Ball Lost Event handling

    /// <summary>
    /// Adds the invoker to the last ball lost event 
    /// </summary>
    /// <param name="invoker"></param>
    public static void LastBallLostInvoker(HUD invoker)
    {
        lastBallLostInvoker = invoker;
        if (lastBallLostListener != null)
        {
            lastBallLostInvoker.AddLastBallLostListener(lastBallLostListener);
        }
    }

    /// <summary>
    /// Adds the listener to the last ball lost event
    /// </summary>
    /// <param name="listener"></param>
    public static void LastBallLostListener(UnityAction listener)
    {
        lastBallLostListener = listener;
        if (lastBallLostInvoker != null)
        {
            lastBallLostInvoker.AddLastBallLostListener(lastBallLostListener);
        }
    }



    #endregion

    #region Reduce blocks left event handling

    /// <summary>
    /// Adds the invoker to the reduce block event
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddReduceBlockInvoker(Block invoker)
    {
        reduceBlockLeftInvokers.Add(invoker);
        foreach(UnityAction listener in reduceBlockLeftListeners)
        {
            invoker.AddReduceBlocksLeftListener(listener);
        }
    }

    /// <summary>
    /// Adds the listener to the reduce block event
    /// </summary>
    /// <param name="listener"></param>
    public static void AddReduceBlockListener(UnityAction listener)
    {
        reduceBlockLeftListeners.Add(listener);
        foreach(Block invoker in reduceBlockLeftInvokers)
        {
            invoker.AddReduceBlocksLeftListener(listener);
        }
    }


    #endregion
}
