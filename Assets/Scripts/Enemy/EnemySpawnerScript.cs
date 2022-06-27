using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public Transform[] enemiesPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i < enemiesPrefab.Length; i++)
            {
                Instantiate(enemiesPrefab[i],enemiesPosition[i].transform.position,enemiesPosition[i].transform.rotation);
            }
            gameObject.SetActive(false);
        }
    }
}
