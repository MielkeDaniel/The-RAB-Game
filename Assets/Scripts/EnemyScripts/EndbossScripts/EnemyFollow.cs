using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    public NavMeshAgent enemy;
    private Transform player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Set the enemy's targetposition to the players position
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
