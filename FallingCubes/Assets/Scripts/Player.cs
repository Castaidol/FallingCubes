using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {



    public float rotationPeriod = 0.3f;     
    public float sideLength = 1f;

    bool isRotate = false;                  
    float directionX = 0;                   
    float directionZ = 0;                   

    Vector3 startPos;                       
    float rotationTime = 0;                
    float radius;                           
    Quaternion fromRotation;               
    Quaternion toRotation;                 

   
    void Start()
    {
        radius = sideLength * Mathf.Sqrt(2f) / 2f;

    }

   
    void Update()
    {
        float x = 0;
        /*float direX;
        direX = Input.acceleration.x;

        if (direX <= -0.2f) x = -1;
        if (direX >= 0.2f) x = 1;
        if (direX > -0.2 && direX < 0.2) x = 0;
*/
        if (transform.position.x >= -10.5f && transform.position.x <= 10.5f) x = Input.GetAxisRaw("Horizontal");
        else if (transform.position.x < -10.5 && Input.GetAxisRaw("Horizontal") >= 0) x = Input.GetAxisRaw("Horizontal");
        else if (transform.position.x > 10.5 && Input.GetAxisRaw("Horizontal") <= 0) x = Input.GetAxisRaw("Horizontal");


        if ((x != 0 ) && !isRotate)
        {
            directionX = -x;                                                            
                                                                      
            startPos = transform.position;                                             
            fromRotation = transform.rotation;                                        
            transform.Rotate(0, 0, directionX * 90, Space.World);    
            toRotation = transform.rotation;                                           
            transform.rotation = fromRotation;                                        
            rotationTime = 0;                                                          
            isRotate = true;                                                           
        }
    }

    void FixedUpdate()
    {

        if (isRotate)
        {

            rotationTime += Time.fixedDeltaTime;                                   
            float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          

         
            float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);                  
            float distanceX = -directionX * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));     
            float distanceY = radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));                        
            float distanceZ = directionZ * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));          
            transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);                       


            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      


            if (ratio == 1)
            {
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
            }
        }
    }

	/*
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.acceleration.x, 0, 0);
	}*/
}
