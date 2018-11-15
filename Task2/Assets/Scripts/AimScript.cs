using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public Transform upperBody;
    public Vector3 offsetpos;
    float dist = 15;

    void Start () {
	}
    

    void LateUpdate () {

        if (PlayerScript.onAction && PlayerScript.onShoot)
        {
            if (PlayerScript.isMouseAim)
            {
                // Mouse Aim
                dist = Vector3.Distance(Camera.main.transform.position, target.position);
                Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist));

                upperBody.LookAt(pos + offsetpos);
                upperBody.rotation = upperBody.rotation * Quaternion.Euler(offset);
            }
            else
            {
                //Auto Aim
                upperBody.LookAt(target.position);
                upperBody.rotation = upperBody.rotation * Quaternion.Euler(offset);
            }
        }

    }
}