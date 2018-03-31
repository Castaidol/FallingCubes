using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour {

    public float Speed;
    float targetY;
    Vector3 targetPosition;
    Vector3 startPosition;

    public GameObject cube;

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

            BoxCollider box = GetComponent<BoxCollider>();
            box.enabled = false;
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;

            InstantiateCubes();
        }
	}

	private void Update()
	{
        startPosition = transform.position;
        StartCoroutine(FallingSlowly());
	}



    void InstantiateCubes()
    {
        Vector3 position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.55f, transform.position.z -0.5f);
        InstantiateOneCube(position);
    }

    void InstantiateOneCube(Vector3 position)
    {
        Instantiate(cube, position, Quaternion.identity, transform);
    }

}
