using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool moveRight;

    public GameObject point1;
    public GameObject point2;
    public float speed = 5.0f;

    private void Start()
    {
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position == point1.transform.position){
            moveRight = !moveRight;

        }
        else if(transform.position == point2.transform.position)
        {
            moveRight = !moveRight;
        }

        if (moveRight) { 
            transform.position = Vector3.MoveTowards(
                transform.position,
                point1.transform.position,
                speed * Time.deltaTime
                );
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                point2.transform.position,
                speed * Time.deltaTime
                );
        }
    }
}
