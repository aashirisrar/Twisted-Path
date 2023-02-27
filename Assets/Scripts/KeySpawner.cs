using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        Instantiate(spawnPoints[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
