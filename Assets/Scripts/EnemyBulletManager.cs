/*******************
File name: EnemyBulletManager.cs
Author: Shun min Hsieh
Student Number: 101212629
Date last Modified: 2020/10/25
Program description: A class controls the creation and use of the enemy's bullet pool.
Revision History:
2020/10/24
 - Added Start function
 - Added _BuildBulletPool function
 - Added GetBullet function
 - Added ReturnBullet function
2020/10/25
 - Modified GetBullet function

Class:
    EnemyBulletManager
Functions:
    Start
    _BuildBulletPool
    GetBullet
    ReturnBullet
*******************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int maxBullets;
    private Queue<GameObject> m_bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    private void _BuildBulletPool()
    {
        // create emtpy Queue structrue
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < maxBullets; count++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        // Set a new direction for the bullet according to the shooting enemy's position
        //newBullet.GetComponent<EnemyBulletController>().SetNewDirection(position);
        EnemyBulletController bulletCon;
        if (newBullet.GetComponent<EnemyBulletController>() != null)
        {
            bulletCon = newBullet.GetComponent<EnemyBulletController>();
            bulletCon.SetNewDirection(position);
        }
        return newBullet;
    }

    public void ReturnBullet(GameObject returnBullet)
    {
        returnBullet.SetActive(false);
        m_bulletPool.Enqueue(returnBullet);
    }
}
