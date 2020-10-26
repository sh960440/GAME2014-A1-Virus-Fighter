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
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);
            
            if (worldTouch.x <= transform.position.x + 0.2f
             && worldTouch.x >= transform.position.x - 0.2f
             && worldTouch.y <= transform.position.y + 0.2f
             && worldTouch.y >= transform.position.y - 0.2f
            )
            {
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
