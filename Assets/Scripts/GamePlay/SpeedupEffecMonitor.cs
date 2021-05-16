using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffecMonitor : MonoBehaviour
{
    #region Fields

    //timer for speedup event is currently active
    Timer timerSpeedupActive;
    //inform speedup effect is currently active
    bool speedupEffectActive;
    //speedupfactor
    float speedupFactor = 2f;
    //time left in the speedup effect
    float timeLeftSpeedupEffect;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the state of speedup effect (true= currently active)
    /// </summary>
    public bool SpeedupEffectActive
    {
        get { return speedupEffectActive; }
    }

    /// <summary>
    /// Gets the speedup factor
    /// </summary>
    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }

    /// <summary>
    /// Gets the time left in the speedup effect 
    /// </summary>
    public float TimeLeftSpeedupEffect
    {
        get { return timeLeftSpeedupEffect; }
    }
    #endregion

    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        //add speedup event timer
        timerSpeedupActive = gameObject.AddComponent<Timer>();

        //Make this class listens for the speedupEffectActivated
        EventManager.AddSpeedupListener(HandleSpeedupEffectActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        //speedup effect time left
        timeLeftSpeedupEffect = timerSpeedupActive.TimeLeft;

        if (timerSpeedupActive.Finished)
        {
            speedupEffectActive = false;
            speedupFactor = 1;
        }

    }

    /// <summary>
    /// Handles the speedup effect event 
    /// </summary>
    /// <param name="duration"></param>
    void HandleSpeedupEffectActivatedEvent(float duration)
    {
        if (!timerSpeedupActive.Running)
        {
            timerSpeedupActive.Duration = duration;
            timerSpeedupActive.Run();
            speedupEffectActive = true;
        }
        else
        {
            timerSpeedupActive.AddTime(duration);
        }
    }

    #endregion
}
