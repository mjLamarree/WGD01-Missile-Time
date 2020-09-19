using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFleaBehaviour : MonoBehaviour
{
    public int healthPoints;
    public int moveSpeed;
    public Transform movepointA;
    public Transform movepointB;
    public bool isMoving;
    
    void Start()
    {
        healthPoints = 10;
        isMoving = true;
        FleaMoveDown();
    }

    void Update()
    {
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        healthPoints--;
          
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.GetComponentInParent<PlayerController>().gameObject);
    }

    public void FleaMoveDown()
    {
        while (isMoving)
        {
            Vector3.MoveTowards(transform.position, movepointB.position, moveSpeed * Time.deltaTime);
        }
    }

    public void FleaMoveUp()
    {
        while (isMoving)
        {
            Vector3.MoveTowards(transform.position, movepointA.position, moveSpeed * Time.deltaTime);
        }
    }

}
