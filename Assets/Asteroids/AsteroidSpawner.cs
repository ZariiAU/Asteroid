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

    public void SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab, Utilities.GetRandomPosOffScreen(), Quaternion.identity);
    }
}
