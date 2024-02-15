using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPathMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 5f;
    private int waypointIndex = 0;

    private void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Transform targetWaypoint = waypoints[waypointIndex];
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

            if (transform.position == targetWaypoint.position)
            {
                waypointIndex++;
            }
        }
    }
}
