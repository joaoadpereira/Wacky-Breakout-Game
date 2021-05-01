using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 400;
    static float ballDeadTime = 9;
    static float ballMinSpawnTime = 4;
    static float ballMaxSpawnTime = 11;
    static float initialNumberBalls = 4;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the time to destroy a ball 
    /// </summary>
    public float BallDeadTime
    {
        get { return ballDeadTime; }
    }

    /// <summary>
    /// Gets the min time to spawn ball
    /// </summary>
    public float BallMinSpawnTime
    {
        get { return ballMinSpawnTime; }
    }

    /// <summary>
    /// Gets the max time to spawn ball
    /// </summary>
    public float BallMaxSpawnTime
    {
        get { return ballMaxSpawnTime; }
    }

    /// <summary>
    /// Gets the initial number of balls
    /// </summary>
    public float InitialNumberBalls
    {
        get { return initialNumberBalls; }
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        //read and save configuration data from file
        StreamReader input = null;
        try
        {
            //create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            //read in name and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            //set configuration data fields
            SetConfigurationDataFields(values);

        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    static void SetConfigurationDataFields(string csvValues)
    {

        string[] values = csvValues.Split(',');

        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballDeadTime = float.Parse(values[2]);
        ballMinSpawnTime = float.Parse(values[3]);
        ballMaxSpawnTime = float.Parse(values[4]);
        initialNumberBalls = float.Parse(values[5]);

    }

    #endregion
}
