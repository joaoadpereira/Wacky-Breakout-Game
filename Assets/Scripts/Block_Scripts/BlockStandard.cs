using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStandard : Block
{
    void Start()
    {
        //Setup data for this block
        destroyPoints = ConfigurationUtils.BlockStandardPoints;
        percentageSpawn = ConfigurationUtils.BlockStandardProbability;
    }



}
