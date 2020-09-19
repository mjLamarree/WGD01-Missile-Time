using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplosion : MonoBehaviour
{
    public Animator anim;
    public GameObject missileBody;
    public GameObject missileTailFlame;
    public Component missileBehaviorScript;
    public Component missileBoxCollider;
    void Start()
    {
        anim = missileBody.GetComponent<Animator>();
        missileBoxCollider = missileBody.GetComponent<BoxCollider2D>();
        missileBehaviorScript = missileBody.GetComponent<MissileBehavior>();
        StartCoroutine("MissileExplosionCountdown");
    }

    public IEnumerator MissileImpact()
    {
        StopCoroutine("MissileExplosionCountdown");
        anim.Play("explosion");
        Destroy(missileBoxCollider);
        Destroy(missileBehaviorScript);
        Destroy(missileTailFlame);
        Debug.Log("Tailflame dead");
        yield return new WaitForSeconds(1);
        Destroy(missileBody);
    }

    public IEnumerator MissileExplosionCountdown()
    {
        yield return new WaitForSeconds(180f);
        StartCoroutine("MissileImpact");
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("MissileImpact");
    }
}
