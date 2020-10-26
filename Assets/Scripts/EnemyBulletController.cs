/*******************
File name: EnemyBulletController.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/26
Program description: A class controls the direction, movement and collision of the enemy bullet.
Revision History:
2020/10/24
 - Added Start function
 - Added Update function
 - Added _Move function
 - Added OnTriggerEnter2D function
 - Added _CheckBounds function
2020/10/25
 - Added SetNewDirection function
 - Modified _Move function
2020/10/26
 - Modified OnTriggerEnter2D function

Class:
    EnemyBulletController
Functions:
    Start
    Update
    _Move
    OnTriggerEnter2D
    _CheckBounds
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletController : MonoBehaviour
{
    public float movingSpeed;
    public float verticalBoundary;
    public PlayerController player;
    public EnemyBulletManager bulletManager;

    Vector3 direction = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<EnemyBulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    public void SetNewDirection(Vector3 enemyPos)
    {
        player = FindObjectOfType<PlayerController>(); // Find the player
        Vector3 plauerPos = player.transform.position; // Get the player's position
        Vector3 distance = enemyPos - plauerPos;
        direction = distance.normalized; // Determine the shooting direction
        //Debug.Log("Distance: " + distance);
        //Debug.Log("Direction: " + direction);
    }

    private void _Move()
    {
        // Move towards the target direction
        transform.position -= direction * movingSpeed;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // If the bullet hits the player
        if (other.gameObject.tag == "Player")
        {
            // Reduce one life
            player.lives--;
            if (player.lives <= 0) // If the player has no lives
            {
                // Switch to Gameover scene
                SceneManager.LoadScene("Gameover");
            }
            bulletManager.ReturnBullet(gameObject);
        }

        // If the bullet hits a mask or a player's bullet
        if (other.gameObject.tag == "Mask" || other.gameObject.tag == "Bullet")
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    private void _CheckBounds()
    {
        if (transform.position.y < verticalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }
}
