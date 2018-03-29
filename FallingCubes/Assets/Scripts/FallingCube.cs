using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour {

    public float Speed;
    float targetY;
    Vector3 targetPosition;
    Vector3 startPosition;


	void Start () 
    {
        Transform positionFloor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Transform>();
        targetY = positionFloor.position.y;
        targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        startPosition = transform.position;

	}
	


    IEnumerator FallingSlowly()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(startPosition, targetPosition, step);
        yield return null;
    }



	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Floor")
        {
            Destroy(gameObject);
        }
	}

	private void Update()
	{
        startPosition = transform.position;
        StartCoroutine(FallingSlowly());
	}
}
