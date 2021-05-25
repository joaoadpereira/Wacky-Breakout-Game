using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStandard : Block
{
    override protected void Start()
    {
        //Setup data for this block
        destroyPoints = ConfigurationUtils.BlockStandardPoints;
        percentageSpawn = ConfigurationUtils.BlockStandardProbability;

        base.Start();
    }



}
