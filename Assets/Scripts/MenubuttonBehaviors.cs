﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenubuttonBehaviors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Play");
    }

    public void OnInstructionsButtonPressed()
    {
        SceneManager.LoadScene("Instructions");
    }
}
