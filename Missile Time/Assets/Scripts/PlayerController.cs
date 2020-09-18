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
    private bool shootPlayerLock = false;
       
    public float thrust = 1.0f;
    public GameObject aimCursor;
    public Rigidbody2D playerRigidBody;

    private void Awake()
    {
        originalScale = transform.localScale;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Surface")
        {

            transform.parent = collision.transform;

            if (shootPlayerLock)
            {
                StopPlayer();
                shootPlayerLock = false;
                aimCursor.SetActive(true);
            }
        }
   
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Surface")
        {
            shootPlayerLock = false;
            aimCursor.SetActive(true);
        }

    }

}
