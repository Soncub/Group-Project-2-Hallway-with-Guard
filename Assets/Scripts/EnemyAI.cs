using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public Animator animator;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public float sightRange;
    public bool playerInSightRange;
    // {
    //     // get{return _playerInSightRange;}
    //     // set {
    //     //     if (value == false && _playerInSightRange == true) walkPointSet = false;
    //     //     _playerInSightRange = value;
    //     // }
    // }
    private bool _playerInSightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        enemy = GetComponent<NavMeshAgent>();
        animator.Play("Walk");
    }
    private void Update()
    {
        //if (walkPointSet == true) animator.Play("Walk");
        //else animator.Play("Idle");
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if(!playerInSightRange)
        {
            Patrol();
        }
        if(playerInSightRange)
        {
            Chase();
        }   
    }
    private void Patrol()
    {
        if (!walkPointSet)SearchWalkPoint();
        if (walkPointSet)
        {
            enemy.SetDestination(walkPoint);
            enemy.speed = 1f;
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint,-transform.up,2f,whatIsGround)) walkPointSet=true;
    }
    private void Chase()
    {
        enemy.speed = 2.5f;
        enemy.SetDestination(player.position);
        // walkPointSet = true;
    }
}
