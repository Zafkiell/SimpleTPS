using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour
{ 
    public enum SpawnState{SPAWNING,WAITING,COUNTING};
    private SpawnState state = SpawnState.COUNTING;
    public GameManagerScript managerScript;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public Transform[] enemiesPositions;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //check if enemies are still alive
            if(!EnemyisAlive()){
                //begin new round
                WaveCompleted();
            }else{
                return;
            }
        }
        if(waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }else{
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE! Looping...");
            //managerScript.OpenResults();
            managerScript.TransitionAnim();
            
        }else
        {
            nextWave++;
        }
    }
    bool EnemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        //spawn wave
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[i],i);
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy,int index)
    {
        //spawn enemy
        Instantiate(_enemy,waves[nextWave].enemiesPositions[index].position,waves[nextWave].enemiesPositions[index].rotation);
    }
}
