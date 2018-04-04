using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIsland : MonoBehaviour {

    public float rotationSpeed;
    public float floatingSpeed;
    public bool isRotating;
    public bool isFloating;
    public bool isGoingDown;
    public float topOffset;
    public float bottomOffset;

    private Transform transformIsland;
    private Vector3 maxHight;
    private Vector3 minHight;
    private Vector3 targetposition;

	void Start () 
    {
        transformIsland = transform;

        maxHight = new Vector3(transform.position.x, transform.position.y + topOffset, transform.position.z);
        minHight = new Vector3(transform.position.x, transform.position.y - bottomOffset, transform.position.z);
        if (isGoingDown) targetposition = minHight;
        else targetposition = maxHight;
	}
	
	
	void Update ()
    {
        if(isRotating) transformIsland.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (transform.position.y >= maxHight.y - 3) targetposition = minHight;
        if (transform.position.y <= minHight.y + 3) targetposition = maxHight;

        if (isFloating) FloatingIsland(targetposition);
            
        
	}

    void FloatingIsland(Vector3 targetPosition)
    {
        transformIsland.position = Vector3.Lerp(transform.position, targetPosition, floatingSpeed * Time.deltaTime);
    }
}
