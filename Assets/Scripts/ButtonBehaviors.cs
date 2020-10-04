/*********
File name: ButtonBehaviors.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/04
Program description: C# script for button behaviors throughout the game.
Revision History:
2020/10/04
 - Added OnPlayButtonPressed()
 - Added OnInstructionsButtonPressed()
 - Added OnBackToMenuButtonPressed()
*********/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonPressed() // For buttons pointing to the play scene.
    {
        SceneManager.LoadScene("Play");
    }

    public void OnInstructionsButtonPressed() // For buttons pointing to the instructions scene.
    {
        SceneManager.LoadScene("Instructions");
    }

    public void OnBackToMenuButtonPressed() // // For buttons pointing to the main menu.
    {
        SceneManager.LoadScene("Menu");
    }
}
