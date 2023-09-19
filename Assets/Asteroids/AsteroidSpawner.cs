using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float maxForce;
    [SerializeField] float minForce;
    [SerializeField] int asteroidSpawnAmount = 6;

    private void Start()
    {
        cam = Camera.main;
        for(int i = 0; i < asteroidSpawnAmount; i++)
        {
            SpawnAsteroid();
        }
    }

    public void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab, Utilities.GetRandomPosOffScreen(cam), Quaternion.identity);
    }
}
