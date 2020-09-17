using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using TreeEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    private Vector2 force;
    private bool shootPlayerLock = true;

    public float thrust = 1.0f;
    public GameObject aimCursor;
    public Rigidbody2D playerRigidBody;


    private void Update()
    {

        aimCursor.GetComponent<Rigidbody2D>().rotation = GetAngleToPointCursorAt(Input.mousePosition);
        aimCursor.transform.position = this.transform.position;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pressing Down");
            StartCoroutine(ShootPlayer(Input.mousePosition));
            this.playerRigidBody.isKinematic = false;
        }

    }

    private void FixedUpdate()
    {

    }

    IEnumerator ShootPlayer(Vector3 mousePos)
    {

        Vector2 mousePositionRelativeToWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 pointerDirection = mousePositionRelativeToWorld - playerRigidBody.position;

        force = pointerDirection * thrust * Time.deltaTime;
        playerRigidBody.AddForce(force, ForceMode2D.Impulse);

        yield return null;

        shootPlayerLock = true;

    }

    IEnumerator StopPlayer()
    {
        playerRigidBody.AddForce(-force, ForceMode2D.Impulse);
        yield return null;
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

            StartCoroutine(StopPlayer());

            if (shootPlayerLock)
            {
                this.playerRigidBody.Sleep();
                shootPlayerLock = false;
            }
            transform.parent = collision.transform;
        }
   
    }

}
