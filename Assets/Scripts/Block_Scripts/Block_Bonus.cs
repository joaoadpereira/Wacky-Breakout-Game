using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Bonus : Block
{
    
    // Start is called before the first frame update
    override protected void Start()
    {
        destroyPoints = ConfigurationUtils.BlockBonusPoints;
        percentageSpawn = ConfigurationUtils.BlockBonusProbability;

        base.Start();
    }


}
