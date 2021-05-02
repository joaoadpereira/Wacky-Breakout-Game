using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Standard : Block
{
    override protected void Start()
    {
        //Setup data for this block
        destroyPoints = ConfigurationUtils.BlockStandardPoints;
        percentageSpawn = ConfigurationUtils.BlockStandardProbability;
    }

    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

}
