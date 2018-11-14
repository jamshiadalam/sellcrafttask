using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent NMAgent;
    Ray ray;
    RaycastHit hit;
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                NMAgent.SetDestination(hit.point);
            }
        }
		
	}
}
