﻿using System.Collections;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
