using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public Transform targetObject;
    public GameObject Skeleton;
    public float spawnDelay = 10;
    public float spawnDelayMax = 10;
    public float spawnRate = 10;
    void Update()
    {
        spawnDelay = spawnDelay - spawnRate * Time.deltaTime;
        Debug.Log(spawnDelay);
        if (spawnDelay < 0)
        {
            spawnDelay = spawnDelayMax;
            GameObject Fireball_clone = Instantiate(Skeleton, targetObject.position, targetObject.rotation);
        }
    }
}
