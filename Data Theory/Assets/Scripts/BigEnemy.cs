using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy
{
    private NavMeshAgent agent;
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
        Set();
    }
    protected override void Set()
    {
        health = 3f;
        speed = 2f;
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }
}
