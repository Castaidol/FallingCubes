using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCubes : MonoBehaviour {
    
    public GameObject cube;
    [Header("Explosion Force")]
    public float minForce;
    public float maxForce;

    float offset = 0.33f;
    float blastForce;

	void Start () 
    {
        blastForce = Random.Range(minForce, maxForce);
        InstantiateCubes();
	}
	
	
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            ExplodeInCubes();
        }
	}

    void ExplodeInCubes()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach(Collider nearbyCollider in colliders)
        {
            Rigidbody rb = nearbyCollider.GetComponent<Rigidbody>();
            if(rb != null)
            {
                float offsetPos = offset * Random.Range(-1f, 1f);
               
                Vector3 explosionPosition = new Vector3(transform.position.x + offsetPos, transform.position.y - 1f, transform.position.z + offsetPos);
                rb.AddExplosionForce(blastForce, explosionPosition, 2f);
            }
        }
    }

    void InstantiateCubes()
    {
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    Vector3 position = new Vector3(transform.position.x + x * offset, transform.position.y + y * offset, transform.position.z + z * offset);
                    InstantiateOneCube(position);
                }
            }
        }
    }

        void InstantiateOneCube(Vector3 position)
    {
        Instantiate(cube, position, Quaternion.identity, transform);
    }
}
