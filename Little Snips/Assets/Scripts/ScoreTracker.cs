using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    //public int score;
    public static int scoreAmount;
    public static int scoreAdd;
    public static int scoreSubtract;

    void Start()
    {
        scoreAmount = 0;
        scoreAdd = 3;
        scoreSubtract = 1;
    }

    void Update()
    {

    }
}
