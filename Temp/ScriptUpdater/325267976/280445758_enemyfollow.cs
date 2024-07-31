using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public Transform target;


    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)//if the enemy has a target to follow ....
        {
            agent.SetDestination(target.position);//set that target's current position as this enemy's destination
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))// if the object this enemy just hit is the player...
        {
            //Despwan the player, and tell the GameManager to reset the current level
            Destroy(other.gameObject);
            GameManager.instance.GameOver();
        }
    }
}

