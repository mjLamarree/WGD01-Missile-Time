using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    public GameObject missileHead;
    public GameObject missileTarget;

    public float missileSpeed;
    private float targetY;
    private float targetX;
    void Start()
    {
        missileTarget = GameObject.FindGameObjectWithTag("Boss");
        targetY = missileTarget.GetComponent<Transform>().position.y + Random.Range(-10f, 10f);
        targetX = missileTarget.GetComponent<Transform>().position.x + Random.Range(-10f, 10f);
    }

    void Update()
    {


        MissileMovement();
        
    }

    public void MissileMovement()
    {

        transform.position = 
            Vector3.MoveTowards(transform.position, new Vector3(targetX, targetY, 0f), missileSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Surface"))
        {
            GetComponentInChildren<MissileExplosion>().StartCoroutine("MissileImpact");
        }

    }


}
