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
        Scoreboard.score = 0;
        touchesEnd = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        firingDelay += Time.deltaTime;

        scoreText.text = "Score: " + Scoreboard.score;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(enemies.Length <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
        
    }

    public void Fire()
    {
        if (firingDelay >= 0.5f)
        {
            bulletManager.GetBullet(new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z));
            firingDelay = 0;
            GetComponent<AudioSource>().clip = soundclips[0];
            GetComponent<AudioSource>().Play();
        }
    }

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
