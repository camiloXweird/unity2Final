// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class ControlPatrullaje : MonoBehaviour
{

    public Vector3[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        agent.destination = points[destPoint];
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}