using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AsteroidSpawner : MonoBehaviour
{
    public static AsteroidSpawner Instance;

    [SerializeField] Camera cam;
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] GameObject player;
    [SerializeField] float maxForce;
    [SerializeField] float minForce;
    [SerializeField] int activeWaveNumber = 0;
    private int activeAsteroidCount = 0;
    public int ActiveAsteroids { get { return activeAsteroidCount; } set { activeAsteroidCount = value; } }
    [SerializeField] List<int> asteroidWaves = new List<int>();
    [SerializeField] List<Asteroid> asteroidPool;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        cam = Camera.main;
        asteroidPool = new List<Asteroid>();

        // Spawn the pooled asteroids
        for (int i = 0; i < asteroidWaves[asteroidWaves.Count - 1]; i++)
        {
            // Disable them and add them to pool
            Asteroid a = SpawnAsteroid();
            a.gameObject.SetActive(false);
            asteroidPool.Add(a);
        }

        // Spawn the first wave
        SpawnWave(0);
    }

    private void Update()
    {
        if (activeAsteroidCount <= 0)
        {
            activeWaveNumber++;
            SpawnWave(activeWaveNumber);
        }
    }

    public Asteroid SpawnAsteroid()
    {
        GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(100, 100), Quaternion.identity);
        return asteroid.GetComponent<Asteroid>();
    }

    void SpawnWave(int waveID)
    {
        if (waveID > asteroidWaves.Count - 1)
        {
            Debug.LogError("Wave ID does not exist.");
            return;
        }
        for (int i = 0; i < asteroidWaves[activeWaveNumber]; i++)
        {
            asteroidPool[i].gameObject.SetActive(true);
            asteroidPool[i].GetComponent<SpriteRenderer>().enabled = true;
            asteroidPool[i].GetComponent<PolygonCollider2D>().enabled = true;
            asteroidPool[i].transform.position = Utilities.GetRandomPosOffScreen(cam);
            asteroidPool[i].LaunchAtTarget2D(asteroidPool[i].GetComponent<Rigidbody2D>(), PlayerTracker.Instance.Player.transform.position);
            ActiveAsteroids++;
        }
    }
}