using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    public GameObject missileHead;
    public GameObject missileTarget;

    public float missileSpeed;

    void Start()
    {
       
    }

    void Update()
    {
        MissileMovement();
        
    }

    public void MissileMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, missileTarget.GetComponent<Transform>().position, missileSpeed * Time.deltaTime);
    }



}
