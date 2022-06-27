using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EnemyChase : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    GameObject[] players;
    List<GameObject> deadPlayers;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(players.Length < 2){
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }else{
            FindTarget();
        }
        agent.SetDestination(target.position);
    }
    void FindTarget()
    {
        
        float dist1 = Vector3.Distance(transform.position,players[0].transform.position);
        float dist2 = Vector3.Distance(transform.position,players[1].transform.position);

        if(dist1 > dist2 && players[1].activeSelf == true)
        {
            target = players[1].transform;
        }
         else if(players[0].activeSelf == true)
        {
            target = players[0].transform;
        }else{
            target = players[1].transform; 
        } 
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
