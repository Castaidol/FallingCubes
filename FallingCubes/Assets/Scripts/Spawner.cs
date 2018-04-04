using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cube;
    public GameObject coin;
    [Header("Time to spawn")]
    public float minTime;
    public float maxTime;
    public float offsetUnit;

    int offsetMultiplier;


	private void Start()
	{
        InvokeRepeating("InstantiateCubeSecond", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
	}


    private void InstantiateCubeSecond()
    {
        offsetMultiplier = Random.Range(-3, 3);
        float offsetX = (float)offsetMultiplier * offsetUnit;
        Vector3 InstaPosition = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z);

        GameObject toSpawn;

        float rn = Random.Range(0, 100);

        if (rn <= 82) toSpawn = cube;
        else toSpawn = coin;

        Instantiate(toSpawn, InstaPosition, Quaternion.Euler(90, 0, 0));
    }
}
