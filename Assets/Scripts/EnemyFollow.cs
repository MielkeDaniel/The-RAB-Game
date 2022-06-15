using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    public NavMeshAgent Enemy;
    public Transform Player;

    // Set the enemy's targetposition to the players position
    void Update()
    {
        Enemy.SetDestination(Player.position);
    }
}
