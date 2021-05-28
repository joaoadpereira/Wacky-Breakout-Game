using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Speedup : Block
{

    // Start is called before the first frame update
    override protected void Start()
    {
        destroyPoints = ConfigurationUtils.BlockSpeedupPoints;
        percentageSpawn = ConfigurationUtils.BlockSpeedupProbability;
        effect = PickupEffect.Speedup;

        base.Start();
    }



    //protected override void ActionBlock()
    //{
    //    base.ActionBlock();
    //}
}
