using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    public int indexNum;
    public PlayerController player;

    void Start()
    {
    }

    void Update()
    {
        if (player.lives < indexNum)
        {
            Destroy(gameObject);
        }
    }
}
