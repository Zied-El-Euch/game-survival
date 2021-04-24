using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnplace : MonoBehaviour
{
    public GameObject[] spawnLocations;
    public GameObject but ;

    private void Awake()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("spawnpoint");
    }

    private void Start()
    {
        Spawning();
    }

    void Spawning()
    {
        int s = Random.Range(0, spawnLocations.Length);
        Instantiate(but, spawnLocations[s].transform.position, Quaternion.identity);
    }
}
       































