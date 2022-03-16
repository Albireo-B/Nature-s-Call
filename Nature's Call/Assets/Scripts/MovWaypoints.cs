using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovWaypoints : MonoBehaviour
{
    public GameObject[] m_waypoints;
    public int m_currentWaypointId = 0;

    public float m_minDist;
    public float m_speed;

    public bool m_rand = false;
    public bool m_go = true;

    public Dog m_dog;

    void Start()
    {
        m_dog.m_isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, m_waypoints[m_currentWaypointId].transform.position);

        if (m_go)
        {
            if (dist > m_minDist)
            {
                Move();
            }
            else
            {
                if (!m_rand)
                {
                    if (m_currentWaypointId + 1 == m_waypoints.Length)
                    {
                        m_currentWaypointId = 0;
                    }
                    else
                    {
                        m_currentWaypointId++;
                    }
                }
                else
                {
                    m_currentWaypointId = Random.Range(0, m_waypoints.Length);
                }
            }
        }
    }

    private void Move()
    {
        gameObject.transform.LookAt(m_waypoints[m_currentWaypointId].transform.position);
        gameObject.transform.position += gameObject.transform.forward * m_speed * Time.deltaTime;
        m_dog.m_isRunning = true;
    }
}
