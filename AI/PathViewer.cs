using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathViewer : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    LineRenderer lineRenderer;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lineRenderer = (GetComponent<LineRenderer>());
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(navMeshAgent.path.corners);
    }
}
