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

    private void Start()
    {
        SpawnAsteroid();
        SpawnAsteroid();
        SpawnAsteroid();
        SpawnAsteroid();
    }

    void SpawnAsteroid()
    {
        Rigidbody2D asteroid = Instantiate(asteroidPrefab, GetRandomPosOffScreen(), Quaternion.identity).GetComponent<Rigidbody2D>();
        asteroid.AddForce((player.GetComponent<Rigidbody2D>().position - asteroid.position).normalized * Random.Range(minForce, maxForce));

    }
    private Vector3 GetRandomPosOffScreen()
    {

        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);
        x += Mathf.Sign(x);
        y += Mathf.Sign(y);
        Vector3 randomPoint = new(x, y);

        randomPoint.z = 5f; // set this to whatever you want the distance of the point from the camera to be. Default for a 2D game would be 10.
        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(randomPoint);

        return worldPoint;
    }

    private void Update()
    {
        
    }
}
