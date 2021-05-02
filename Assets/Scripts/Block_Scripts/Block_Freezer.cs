using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Freezer : Block
{
    // Start is called before the first frame update
    protected override void Start()
    {
        destroyPoints = ConfigurationUtils.BlockFreezerPoints;
        percentageSpawn = ConfigurationUtils.BlockFreezerProbability;
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    public override void ActionBlock()
    {
        //Some actions should be implemented here


        base.ActionBlock();
    }
}
