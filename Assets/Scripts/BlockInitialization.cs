using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInitialization : MonoBehaviour
{
    #region Fields

    [SerializeField] GameObject block;

    // Y position of blocks
    float positionY = 3.5f;

    //Number of blocks 
    [SerializeField] int NumberOfBlocks = 6;

    //handle blocks
    GameObject[] blocks;

    #endregion


    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        /*Distribuit blocks*/

        //Get data from block
        float blockWidth = block.GetComponent<BoxCollider2D>().size.x;

        //Calculate space between blocks & limits
        float totalDistance = Mathf.Abs(ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft);
        float distance = (totalDistance - NumberOfBlocks * blockWidth) / (1 + NumberOfBlocks);

        //Instantiate the blocks in the correct position
        blocks = new GameObject[NumberOfBlocks];

        float positionXFirst = ScreenUtils.ScreenLeft + distance + blockWidth / 2;
        float nextPositionX = distance + blockWidth;
        float otherPositionX = positionXFirst + nextPositionX;

        for (int i = 0; i < blocks.Length; i++)
        {

            if (i == 0)
            {
                blocks[i]= Instantiate(block, new Vector2(positionXFirst, positionY), Quaternion.identity);
            }
            else
            {
                Vector2 position = new Vector2(otherPositionX, positionY);
                blocks[i] = Instantiate(block, position, Quaternion.identity);

                otherPositionX += nextPositionX;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion
}
