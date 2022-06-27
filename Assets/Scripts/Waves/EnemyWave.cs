using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] enemiesPositions;

    public void SpawnWave()
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            Instantiate(enemies[i],enemiesPositions[i].transform.position,enemiesPositions[i].transform.rotation);
        }
    }
}
