/*******************
File name: PresentScore.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/26
Program description: A class for presenting final score in the Gameover scene.
Revision History:
2020/10/26
 - Added Start function

Class:
    PresentScore
Functions:
    Start
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentScore : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = Scoreboard.score.ToString();
    }
}
