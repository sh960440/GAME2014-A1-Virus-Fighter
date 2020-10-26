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
        shootingDelay = Random.Range(5.0f, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAttackingEnemy)
        {
            if (timer >= shootingDelay)
            {
                ShootPlayer();
                timer = 0;
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
        if (other.gameObject.tag == "Bullet")
        {
            Scoreboard.score += 100;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.25f);
            if (Random.Range(0.0f, 100.0f) > 80.0f)
            {
                Instantiate(healingItem, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity); 
            }    
        } 
    }
}
