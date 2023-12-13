using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Size of the spawner area")]
    public Vector3 spawnerSize;

    [Header("Rate of spawn")]
    public float spawnRate = 1.0f;

    [Header("Model to spawn")]
    [SerializeField] private GameObject asteroidModel; 

    private float spawnTimer = 0.0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,0,0.7f);
        Gizmos.DrawCube(transform.position, spawnerSize);

    }

    private void Update()
    {
        spawnTimer += Time.deltaTime; 
        if(spawnTimer > spawnRate)
        {
            spawnTimer = 0.0f;
            SpawnAsteroid();
        }

    }

    private void SpawnAsteroid()
    {
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x/2),
                                                              UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y/2),
                                                              UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z/2)
            );

        //GameObject asteroid = Instantiate(asteroidModel, spawnPoint, transform.rotation);
        GameObject asteroid = this.gameObject.GetComponent<ObjectPool>().GetPooledObject().gameObject;
        asteroid.transform.position = spawnPoint;
        asteroid.transform.rotation = transform.rotation; 
        
        asteroid.transform.SetParent(this.transform);
    }
}
