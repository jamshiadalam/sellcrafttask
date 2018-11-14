using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathVisualiser : MonoBehaviour {

    public NavMeshAgent agent;
    LineRenderer lineRenderer;
    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if(agent.hasPath)
        {
            lineRenderer.positionCount = agent.path.corners.Length;
            lineRenderer.SetPositions(agent.path.corners);
            lineRenderer.enabled = true;
        } else
        {
            lineRenderer.enabled = false;
        }
		
	}
}
