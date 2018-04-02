using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed;
    public Vector3 offset;


	
	void FixedUpdate () {

        Vector3 desirePosition = new Vector3(target.position.x, 1, target.position.z) + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        transform.position = smoothedPosition;
	}
}
