using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed = 2f;
    void Start()
    {
        
    }
    void Update()
    {
        Transform wp = waypoints[_currentWaypointIndex];
        if (Vector3.Distance(transform.position, wp.position) < 0.02f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
            transform.LookAt(wp.position);
            enemy.SetDestination(Player.position);
        }
    }
}
