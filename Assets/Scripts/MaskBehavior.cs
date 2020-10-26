/*******************
File name: MaskBehavior.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/23
Program description: A class dealing with the mask's collision.
Revision History:
2020/10/23
 - Added OnTriggerEnter2D function

Class:
    MaskBehavior
Functions:
    OnTriggerEnter2D
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBehavior : MonoBehaviour
{
    // If a mask is hit
    public void OnTriggerEnter2D(Collider2D other)
    {
        AudioSource sound = GetComponent<AudioSource>();
        sound.Play();

        Destroy(gameObject, 0.25f);
    }
}
