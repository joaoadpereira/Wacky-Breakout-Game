using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Freezer : Block
{
    // Start is called before the first frame update
    void Start()
    {
        destroyPoints = ConfigurationUtils.BlockFreezerPoints;
        percentageSpawn = ConfigurationUtils.BlockFreezerProbability;
    }



    public override void ActionBlock()
    {
        //Some actions should be implemented here


        base.ActionBlock();
    }
}
