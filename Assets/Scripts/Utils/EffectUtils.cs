using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils 
{

    #region Properties

    /// <summary>
    /// Gets the state of speedup effect (true= currently active)
    /// </summary>
    public static bool SpeedupEffectActive
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffectActive; }
    }

    /// <summary>
    /// Gets the speedup factor
    /// </summary>
    public static float SpeedupFactor
    {
        get { return GetSpeedupEffectMonitor().SpeedupFactor; }
    }

    /// <summary>
    /// Gets the time left in the speedup effect
    /// </summary>
    public static float TimeLeftSpeedupEffect
    {
        get { return GetSpeedupEffectMonitor().TimeLeftSpeedupEffect; }
    }

    #endregion

    /// <summary>
    /// Gets the SpeedupEffectMonitor attached to the main camera
    /// </summary>
    /// <returns></returns>
    static SpeedupEffecMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffecMonitor>();
    }
}

