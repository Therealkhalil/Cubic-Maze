using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 
    targetPosition = new Vector3(47.62f, 3.01f, 0f) , 
    targetPosition2 = new Vector3(47.62f, 3.01f, -3f);
    [SerializeField] float smoothFactor = 3f;
    private float pos = 0;


    private float distanceTravelled;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z == targetPosition.z)
            pos = 1;
        else if(transform.position.z == targetPosition2.z)
            pos = 0;


        if (pos == 0) 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        else if(pos == 1)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition2, smoothFactor * Time.deltaTime);
    }
}
