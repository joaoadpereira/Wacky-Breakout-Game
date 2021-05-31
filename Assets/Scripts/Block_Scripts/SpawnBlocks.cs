using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnBlocks : MonoBehaviour
{
    #region Fields

    //define block prefabs
    [SerializeField] GameObject standardBlock;
    [SerializeField] GameObject bonusBlock;
    [SerializeField] GameObject freezerBlock;
    [SerializeField] GameObject speedupBlock;

    GameObject selectedBlock;

    //get measurements
    GameObject block;
    float blockHeight;
    float blockWidth;

    float widthScreen;
    float heightScreen;

    //Total number of blocks instantiated
    int n;
    int m;
    int numberOfBlocksInGame;


    #endregion

    #region Properties

    /// <summary>
    /// Gets the numbers of blocks instantiated in the game 
    /// </summary>
    public int NumberOfBlocksInGame
    {
        get { return n*m;}
    }

    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        //get block measurements 
        block = Instantiate(bonusBlock);
        blockHeight = block.GetComponent<BoxCollider2D>().size.y;
        blockWidth = block.GetComponent<BoxCollider2D>().size.x;
        Destroy(block);

        //get screen measurements
        widthScreen = Mathf.Abs(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft);
        heightScreen = Mathf.Abs(ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom);

        //Create the blocks
        CreateBlocks();


    }

    /// <summary>
    /// Creates 3 rows of blocks based centralized in the screen 
    /// </summary>
    private void CreateBlocks()
    {
        //calculate number of blocks per row
        n = Mathf.FloorToInt(widthScreen / blockWidth);

        //Number of blocks per column
        m = 3; 
        //calculate space necessary 
        float space = (widthScreen- n * blockWidth) / 2;

        Vector2 positionReference = new Vector2(ScreenUtils.ScreenLeft + space + blockWidth / 2, ScreenUtils.ScreenTop - heightScreen * 0.2f);
 
        //For each row 
        for(int j=0; j < m; j++)
        {
            //build a column of blocks 
            for(int i=0; i<n; i++)
            {
                SpawnBlock(positionReference);
                positionReference.x += blockWidth;
            }

            //reset x position 
            positionReference.x = ScreenUtils.ScreenLeft + space + blockWidth / 2;
            //change row position 
            positionReference.y -= blockHeight;
        }

    }

    /// <summary>
    /// Spawns a random block (with different probabilities) at a given position
    /// </summary>
    /// <param name="position"></param>
    private void SpawnBlock(Vector2 position)
    {
        //randomly select on block considering different probability
        int randNumber = Random.Range(0, 100);
        

        if(randNumber < ConfigurationUtils.BlockStandardProbability)
        {
            selectedBlock = standardBlock;
        }
        else if( randNumber < ConfigurationUtils.BlockStandardProbability + ConfigurationUtils.BlockBonusProbability)
        {
            selectedBlock = bonusBlock;
        }
        else if(randNumber < ConfigurationUtils.BlockStandardProbability + ConfigurationUtils.BlockBonusProbability + ConfigurationUtils.BlockFreezerProbability)
        {
            selectedBlock = freezerBlock;
        }
        else
        {
            selectedBlock = speedupBlock;
        }

        //instantiate block in a position
        GameObject newBlock= Instantiate(selectedBlock, position, Quaternion.identity);

    }

    #endregion

}
