using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool spawn = true;
    public GameObject prefab;
    public float spawnRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn()); 
    }
    // while spawn is true instatntiate prefab and wait for 1 second
    IEnumerator Spawn()
    {
        while (spawn)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
