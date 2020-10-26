/*******************
File name: HealingItemCollector.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/26
Program description: A class allow the player to pick the healing item up and get score.
Revision History:
2020/10/26
 - Added Update function

Class:
    HealingItemCollector
Functions:
    Update
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItemCollector : MonoBehaviour
{
    public float itemSize;
    bool isCollected = false;
    // Update is called once per frame
    void Update()
    {
        // If the player touches the healing item
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (worldTouch.x <= transform.position.x + itemSize
             && worldTouch.x >= transform.position.x - itemSize
             && worldTouch.y <= transform.position.y + itemSize
             && worldTouch.y >= transform.position.y - itemSize
            )
            {
                // Limit the healing item to be picked only once
                if (!isCollected)
                {
                    Scoreboard.score += 200;
                    isCollected = true;
                }
                
                AudioSource sound = GetComponent<AudioSource>();
                sound.Play();

                Destroy(gameObject, 0.5f);
            }
        }
        
    }
}
