using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected float health;
    protected float speed;
    private NavMeshAgent agent;
    protected SpawnManager spawnManagerScript;
    protected PlayerController playerControllerScript;
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        Set();
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
    protected virtual void Set()
    {
        health = 1f;
        speed = 5f;
        agent.speed = speed;
    }
    protected void Death()
    {
        if(health <= 0 || !playerControllerScript.isGameOn)
        {
            spawnManagerScript.enemyCount -= 1;
            Destroy(gameObject);
        }
    }
    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(other.gameObject);
        }
    }
}
