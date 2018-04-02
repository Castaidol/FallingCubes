using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCube : MonoBehaviour {
    
    public GameObject fallingCubePieces;
    public GameObject playerCubePieces;

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

    IEnumerator DestroyCube(GameObject toDestroy)
    {
        yield return new WaitForSeconds(2f);
        Destroy(toDestroy);
    }

    IEnumerator GameOver()
    {
        Debug.Log("Game Over");
        yield return new WaitForSeconds(0.5f);

    }

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Floor")
        {

            BoxCollider box = GetComponent<BoxCollider>();
            box.enabled = false;
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;

            InstantiateCubes(fallingCubePieces);
            StartCoroutine(DestroyCube(gameObject));
        }

        if(other.tag == "Player")
        {
            Transform playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            BoxCollider PlayerBox = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
            PlayerBox.enabled = false;
            MeshRenderer PlayerMesh = GameObject.FindGameObjectWithTag("Player").GetComponent<MeshRenderer>();
            PlayerMesh.enabled = false;
            InstantiateOneCube(playerTransform.position , playerCubePieces);


            BoxCollider box = GetComponent<BoxCollider>();
            box.enabled = false;
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;

            InstantiateCubes(fallingCubePieces);
            StartCoroutine(DestroyCube(gameObject));
            Time.timeScale = 0.2F;
            StartCoroutine(GameOver());
        }
	}

	private void Update()
	{
        startPosition = transform.position;
        StartCoroutine(FallingSlowly());
	}



    void InstantiateCubes(GameObject effect)
    {
        Vector3 position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.9f, transform.position.z -0.5f);
        InstantiateOneCube(position, effect);
    }

    void InstantiateOneCube(Vector3 position, GameObject effect)
    {
        Instantiate(effect, position, Quaternion.Euler(new Vector3(90, 0, 0)), transform);
    }

}
