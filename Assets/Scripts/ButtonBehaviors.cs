/*******************
File name: ButtonBehaviors.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/04
Program description: A class for button behaviors throughout the game.
Revision History:
2020/10/04
 - Added OnPlayButtonPressed function
 - Added OnInstructionsButtonPressed function
 - Added OnBackToMenuButtonPressed function

Class:
    ButtonBehaviors
Functions:
    OnPlayButtonPressed
    OnInstructionsButtonPressed
    OnBackToMenuButtonPressed
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviors : MonoBehaviour
{
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
