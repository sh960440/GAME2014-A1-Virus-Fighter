/*******************
File name: EnemyController.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/26
Program description: A class controls the enemy's collision and sets it's attack behavior.
Revision History:
2020/10/24
 - Added Start function
 - Added Update function
 - Added ShootPlayer function
 - Added OnTriggerEnter2D function
2020/10/26
 - Modified OnTriggerEnter2D function

Class:
    EnemyController
Functions:
    Start
    Update
    ShootPlayer
    OnTriggerEnter2D
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public EnemyBulletManager bulletManager;
    public bool IsAttackingEnemy = false;
    float shootingDelay = 0.0f;
    float timer = 2.0f;
    public GameObject healingItem;

    // Start is called before the first frame update
    void Start()
    {
        // Give each enemy a random delay time
        shootingDelay = Random.Range(5.0f, 9.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy can attack
        if (IsAttackingEnemy)
        {
            // Check the delay timer
            if (timer >= shootingDelay)
            {
                ShootPlayer();
                timer = 0; // Reset the timer
            }
        }
        timer += Time.deltaTime;
    }

    public void ShootPlayer()
    {
        bulletManager.GetBullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the enemy is hit by a bullet
        if (other.gameObject.tag == "Bullet")
        {
            Scoreboard.score += 100;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.25f);

            // 20% chance to spawn a healing item
            if (Random.Range(0.0f, 100.0f) > 80.0f)
            {
                Instantiate(healingItem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); 
            }    
        } 
    }
}
