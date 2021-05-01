using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    //define text fields
    [SerializeField] TMP_Text textNumberBalls;
    int numberOfBalls=0;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        numberOfBalls = BallUtils.NumberOfBalls;

        //define text fields
        textNumberBalls.text = "Number of balls: " + numberOfBalls;
    }
}
