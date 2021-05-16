using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  static class EventManager 
{

    //event support
    static PickupBlock freezeInvoker;
    static UnityAction<float> freezeListener;

    static List<PickupBlock> speedupInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> speedupListeners = new List<UnityAction<float>>();

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

}
