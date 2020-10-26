using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float movingSpeed;
    public float verticalBoundary;
    public PlayerController player;
    public EnemyBulletManager bulletManager;

    Vector3 targetPos = new Vector3();
    Vector3 direction = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<EnemyBulletManager>();
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    public void SetNewDirection(Vector3 enemyPos)
    {
        player = FindObjectOfType<PlayerController>();
        Vector3 plauerPos = player.transform.position;
        Vector3 distance = enemyPos - plauerPos ;
        direction = distance.normalized;
        //Debug.Log("Distance: " + distance);
        //Debug.Log("Direction: " + direction);
    }

    private void _Move()
    {
        transform.position -= direction * movingSpeed;
        //Debug.Log("Moving direction: " + direction);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.lives--;
            bulletManager.ReturnBullet(gameObject);
        }
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
