using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallDeadTime
    {
        get { return configurationData.BallDeadTime; }
    }

    public static float BallMinSpawnTime
    {
        get { return configurationData.BallMinSpawnTime; }
    }
    
    public static float BallMaxSpawnTime
    {
        get { return configurationData.BallMaxSpawnTime; }
    }

    public static float InitialNumberBalls
    {
        get { return configurationData.InitialNumberBalls; }
    }

    public static float BlockStandardPoints
    {
        get { return configurationData.BlockStandardPoints; }
    }

    public static float BlockBonusPoints
    {
        get { return configurationData.BlockBonusPoints; }
    }

    public static float BlockFreezerPoints
    {
        get { return configurationData.BlockFreezerPoints; }
    }

    public static float BlockSpeedupPoints
    {
        get { return configurationData.BlockSpeedupPoints; }
    }

    public static float BlockStandardProbability
    {
        get { return configurationData.BlockStandardProbability; }
    }

    public static float BlockBonusProbability
    {
        get { return configurationData.BlockBonusProbability; }
    }

    public static float BlockFreezerProbability
    {
        get { return configurationData.BlockFreezerProbability; }
    }

    public static float BlockSpeedupProbability
    {
        get { return configurationData.BlockSpeedupProbability; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
