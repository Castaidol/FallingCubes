using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCoin : MonoBehaviour {
    
    public GameObject fallingCoinPieces;
    public GameObject playerCubePieces;

    public float fallingSpeed;
    public float rotationSpeed;

    bool hit;
    float targetY;
    Vector3 targetPosition;
    Vector3 startPosition;


    void Start()
    {
        Transform positionFloor = GameObject.FindGameObjectWithTag("Floor").GetComponent<Transform>();
        targetY = positionFloor.position.y;
        targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        startPosition = transform.position;
        hit = false;
    }



    IEnumerator FallingSlowly()
    {
        float step = fallingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(startPosition, targetPosition, step);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        yield return null;
    }

    IEnumerator DestroyCube(GameObject toDestroy)
    {
        yield return new WaitForSeconds(2f);
        Destroy(toDestroy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor")
        {
            hit = true;
            StopCoroutine(FallingSlowly());
            MeshCollider box = GetComponentInChildren<MeshCollider>();
            box.enabled = false;
            MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
            mesh.enabled = false;

            InstantiateCubes(fallingCoinPieces);
            StartCoroutine(DestroyCube(gameObject));
        }

        if (other.tag == "Player")
        {
            hit = true;
            StopCoroutine(FallingSlowly());
            MeshCollider box = GetComponentInChildren<MeshCollider>();
            box.enabled = false;
            MeshRenderer mesh = GetComponentInChildren<MeshRenderer>();
            mesh.enabled = false;

            InstantiateCubes(fallingCoinPieces);
            StartCoroutine(DestroyCube(gameObject));
            int coinCount = PlayerPrefs.GetInt("Coin");
            coinCount++;
            PlayerPrefs.SetInt("Coin", coinCount);
        }
    }

    private void Update()
    {
        startPosition = transform.position;
        if(!hit) StartCoroutine(FallingSlowly());
        
    }



    void InstantiateCubes(GameObject effect)
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        InstantiateOneCube(position, effect);
    }

    void InstantiateOneCube(Vector3 position, GameObject effect)
    {
        Instantiate(effect, position, Quaternion.Euler(new Vector3(90, 0, 0)), transform);
    }
}
