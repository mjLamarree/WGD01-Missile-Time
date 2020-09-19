using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TreeEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    private Vector2 force;
    private Vector3 originalScale;
    private string collidedObject;
    private bool shootPlayerLock = false;

    public Sprite jumpSprite;
    public Sprite idleSprite;
    public float thrust = 1.0f;
    public GameObject aimCursor;
    public Rigidbody2D playerRigidBody;

    public event Action revertOnExit;
    public event Action slowDownOnEnter;
    public static PlayerController current;

    public GameObject playerGameObject;
    private void Awake()
    {
        playerGameObject = gameObject;
        current = this;
        originalScale = transform.localScale;
        TriggerJumpAnimation(false);
    }

    private void Update()
    {   

        HandleCursorMovement();

        if (Input.GetButtonDown("Fire1") && shootPlayerLock == false)
        {
            ShootPlayer(Input.mousePosition);
            aimCursor.SetActive(false);
        }

    }

    void HandleCursorMovement()
    {
        aimCursor.GetComponent<Rigidbody2D>().rotation = GetAngleToPointCursorAt(Input.mousePosition);
        aimCursor.transform.position = this.transform.position;
    }

    void MaintainPlayerCharacterScale()
    {
        transform.localScale = originalScale;
    }

    void ShootPlayer(Vector3 mousePos)
    {

        Vector2 mousePositionRelativeToWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 pointerDirection = mousePositionRelativeToWorld - playerRigidBody.position;

        force = pointerDirection * thrust;
        playerRigidBody.AddForce(force, ForceMode2D.Impulse);

        shootPlayerLock = true;

    }

    void StopPlayer()
    {
        playerRigidBody.AddForce(-force, ForceMode2D.Impulse);
        this.playerRigidBody.Sleep();
    }

    float GetAngleToPointCursorAt(Vector3 mousePos)
    {
        Vector2 mousePositionRelativeToWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 pointerDirection = mousePositionRelativeToWorld - playerRigidBody.position;
        float angle = Mathf.Atan2(pointerDirection.y, pointerDirection.x) * Mathf.Rad2Deg - 90f;
        return angle;
    }

    void TriggerJumpAnimation(bool isPlayerOffGround)
    {
        this.GetComponent<Animator>().SetBool("offGround", isPlayerOffGround);
    }

    public void SlowDownMissileEnter()
    {
        if(slowDownOnEnter != null)
        {
            slowDownOnEnter();
        }
    }

    public void RevertMissileExit()
    {
        if (revertOnExit != null)
        {
            revertOnExit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Surface")
        {

            Debug.Log("1");

            collidedObject = collision.collider.name;

            transform.parent = collision.transform;
            TriggerJumpAnimation(false);

            if (shootPlayerLock || collidedObject.Equals(collision.collider.name))
            {
                StopPlayer();
                shootPlayerLock = false;
                aimCursor.SetActive(true);
                slowDownOnEnter();
            }
        }
   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        Debug.Log("2");
        
        
         if (collidedObject.Equals(collision.collider.name))
            {
                shootPlayerLock = false;
                aimCursor.SetActive(true);
                TriggerJumpAnimation(false);
                slowDownOnEnter();
            }
        
  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        Debug.Log("Not Colliding");
        TriggerJumpAnimation(true);
        revertOnExit();

        collidedObject = "";

    }

}
