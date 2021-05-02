using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Speedup : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        destroyPoints = ConfigurationUtils.BlockSpeedupPoints;
        percentageSpawn = ConfigurationUtils.BlockSpeedupProbability;
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    public override void ActionBlock()
    {
        //some actions should be implemented here


        base.ActionBlock();
    }
}
