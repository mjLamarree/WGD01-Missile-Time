using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFleaBehaviour : MonoBehaviour
{
    public int maxHealth;
    public int healthPoints;
    public float moveSpeed;

    public Transform movePointA;
    public Transform movePointB;

    public bool movingUp;
    public bool movingDown;

    public healthbar healthbar;

    void Start()
    {
        healthPoints = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
        if(transform.position == movePointB.position)
        {
            movingUp = false;
            movingDown = true;
        }
        if(transform.position == movePointA.position)
        {
            movingDown = false;
            movingUp = true;
        }

    }

    private void FixedUpdate()
    {
        if (movingUp)
        {
            Debug.Log("Moving up");
            transform.position = Vector3.MoveTowards(transform.position, movePointB.position, moveSpeed * Time.deltaTime);
        }

        if (movingDown)
        {
            Debug.Log("Moving down");
            transform.position = Vector3.MoveTowards(transform.position, movePointA.position, moveSpeed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.GetComponentInParent<PlayerController>().gameObject);
        }
        else if (collision.CompareTag("MoveA"))
        {
            movingDown = false;
            movingUp = true;
        }
        else if (collision.CompareTag("MoveB"))
        {
            movingUp = false;
            movingDown = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        healthPoints--;
        healthbar.SetHealth(healthPoints);
        try { Destroy(collision.collider.GetComponentInParent<PlayerController>()); }
        catch { Destroy(collision.gameObject); }
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(collision.collider.GetComponentInParent<PlayerController>().playerGameObject);
        }

    }



}
