using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cube;
    [Header("Time to spawn")]
    public float minTime;
    public float maxTime;


    int offsetX;
	private void Start()
	{
        InvokeRepeating("InstantiateCubeSecond", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
	}


    private void InstantiateCubeSecond()
    {
        offsetX = Random.Range(-3, 3);
        Vector3 InstaPosition = new Vector3(transform.position.x + (float)offsetX, transform.position.y, transform.position.z);
        Instantiate(cube, InstaPosition, Quaternion.identity);
    }
}
