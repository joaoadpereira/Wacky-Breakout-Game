using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Speedup : Block
{
    // Start is called before the first frame update
    void Start()
    {
        destroyPoints = ConfigurationUtils.BlockSpeedupPoints;
        percentageSpawn = ConfigurationUtils.BlockSpeedupProbability;
    }



    public override void ActionBlock()
    {
        //some actions should be implemented here


        base.ActionBlock();
    }
}
