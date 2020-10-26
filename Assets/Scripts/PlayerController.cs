/*******************
File name: PlayerController.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/27
Program description: A class for the player's movement, shooting, collision and sound effects.
Revision History:
2020/10/22
 - Added Start function
 - Added Update function
 - Added _Move function
 - Added _CheckBounds function
2020/10/23
 - Added Fire function
2020/10/26
 - Modified Fire function
 - Modified Start function
 - Modified Update function
2020/10/27
 - Added OnTriggerEnter2D function

Class:
    PlayerController
Functions:
    Start
    Update
    Fire
    OnTriggerEnter2D
    _Move
    _CheckBounds
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    public float horizontalBoundary;
    public float horizontalSpeed;
    public float maxSpeed;
    public float horizontalTValue;
    private Rigidbody2D m_rigidBody;
    private Vector3 touchesEnd;

    private float firingDelay = 0;

    public int lives = 3;
    public Text scoreText;

    public AudioClip[] soundclips;

    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        Scoreboard.score = 0; // Reset the score in the begining of the game
        touchesEnd = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        firingDelay += Time.deltaTime;

        scoreText.text = "Score: " + Scoreboard.score; // Update the score label's text

        enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Find all enemies

        // If all enemies are destroyed
        if (enemies.Length <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
        
    }

    public void Fire()
    {
        if (firingDelay >= 0.5f)
        {
            bulletManager.GetBullet(new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z));
            firingDelay = 0; // Reset the timer
            GetComponent<AudioSource>().clip = soundclips[0];
            GetComponent<AudioSource>().Play();
        }
    }

    // If the player is hit, play the sound effect
    public void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<AudioSource>().clip = soundclips[1];
        GetComponent<AudioSource>().Play();
    }

    private void _Move()
    {
        float direction = 0.0f;

        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            
            if (worldTouch.x > transform.position.x)
            {
                direction = 1.0f;
            }
            if (worldTouch.x < transform.position.x)
            {
                direction = -1.0f;
            }

            touchesEnd = worldTouch;
        }
        
        if (touchesEnd.y <= -2.5)
        {
            if(touchesEnd.x != 0.0f)
            {
                transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchesEnd.x, horizontalTValue), transform.position.y);
            }
            else
            {
                Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
                m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
                m_rigidBody.velocity *= 0.99f;            
            }
        }
    }

    private void _CheckBounds()
    {
        if(transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        }

        if(transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        }
    }
}
