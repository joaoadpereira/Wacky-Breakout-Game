using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  static class EventManager 
{

    //event support
    static PickupBlock freezeInvoker;
    static UnityAction<float> freezeListener;

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
    /// Adds the listener for the destroy event 
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

}
