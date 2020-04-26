using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    // Configuration Parameters
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        // If it is not done yet traversing movement points
        if(waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            // How fast the ship moves
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            // Move the enemy towards next waypoint
            transform.position = Vector2.MoveTowards(
                transform.position, 
                targetPosition, 
                movementThisFrame);

            // If you have reached a way point, update the next waypoint
            if(transform.position == targetPosition)
            {
                waypointIndex ++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
