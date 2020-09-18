using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    public GameObject missileHead;
    public GameObject missileTarget;

    public float missileSpeed;

    private float speedModifier = 1.0f;

    void Start()
    {
        missileTarget = GameObject.FindGameObjectWithTag("Boss");
        PlayerController.current.slowDownOnEnter += SlowDownSpeed;
        PlayerController.current.revertOnExit += RevertSpeed;
    }

    void Update()
    {
        MissileMovement();
    }

    public void MissileMovement()
    {
        transform.position = new Vector3(transform.position.x - (missileSpeed * speedModifier * Time.deltaTime), transform.position.y, 0);
    }

    void SlowDownSpeed()
    {
        speedModifier = 0.5f;
    }

    void RevertSpeed()
    {
        speedModifier = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Surface"))
        {
            GetComponentInChildren<MissileExplosion>().StartCoroutine("MissileImpact");
        }

    }


}
