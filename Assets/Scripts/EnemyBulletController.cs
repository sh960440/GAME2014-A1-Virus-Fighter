using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public PlayerController player;
    public EnemyBulletManager bulletManager;

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

    private void _Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed, 0.0f);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.lives--;
            bulletManager.ReturnBullet(gameObject);
        }
        if (other.gameObject.tag == "Mask")
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
