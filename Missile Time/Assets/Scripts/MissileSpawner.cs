using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject[] missile;
    public bool spawnersActive;
    void Start()
    {
        StartCoroutine("SpawnMissile");
    }

 
    void Update()
    {
        
    }

    public IEnumerator SpawnMissile()
    {
        while (spawnersActive)
        {
            Instantiate(missile[Random.Range(1,3)], gameObject.transform);
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
        
    }
}
