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
        missileTarget = GameObject.FindGameObjectWithTag("Boss");

    }

    void Update()
    {


        MissileMovement();
        
    }

    public void MissileMovement()
    {

        transform.position = new Vector3(transform.position.x - (missileSpeed * Time.deltaTime), transform.position.y, 0);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Surface"))
        {
            GetComponentInChildren<MissileExplosion>().StartCoroutine("MissileImpact");
        }

    }


}
