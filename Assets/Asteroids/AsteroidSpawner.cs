using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// Handles the spawning and tracking of <see cref="Asteroid"/>s
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    public static AsteroidSpawner Instance;

    [Header("Asteroid Settings")]
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private float maxForce;
    [SerializeField] private float minForce;

    [Header("Asteroid Wave Information")]
    private int activeAsteroidCount = 0;
    public int ActiveAsteroids { get { return activeAsteroidCount; } set { activeAsteroidCount = value; } }
    [SerializeField] private List<int> asteroidWaves = new List<int>(); // Stores the number of asteroids that should be spawned in each wave. Index of each item acts as the "wave number".
    [SerializeField] private int activeWaveNumber = 0;
    [SerializeField] private List<Asteroid> asteroidPool; // List of asteroids currently in the scene.

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

    private void OnDrawGizmos()
    {
        foreach (Asteroid a in asteroidPool)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(a.transform.position, player.transform.position);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(a.transform.position, a.GetComponent<Rigidbody2D>().velocity);
        }
    }

    private void LateUpdate()
    {
        if (activeAsteroidCount <= 0)
        {
            activeWaveNumber++;
            SpawnWave(activeWaveNumber);
        }
    }

    /// <summary>
    /// Instantiates a single asteroid
    /// </summary>
    /// <returns>Reference to the <see cref="Asteroid"/> component on the spawned object</returns>
    public Asteroid SpawnAsteroid()
    {


        GameObject asteroid = Instantiate(asteroidPrefab, Utilities.GetPointOnEdgeOfScreen(cam), Quaternion.identity);
        return asteroid.GetComponent<Asteroid>();
    }

    /// <summary>
    /// Enables a number of asteroids stored in <see cref="asteroidPool"/> based on the integer parameter, given that it is less than asteroidWaves.Count - 1
    /// </summary>
    /// <param name="waveID"></param>
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
            asteroidPool[i].GetComponent<LoopAroundScreen>().hasEnteredScreen = false;
            asteroidPool[i].transform.position = Utilities.GetPointOnEdgeOfScreen(cam);
            asteroidPool[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            asteroidPool[i].LaunchAtTarget2D(asteroidPool[i].GetComponent<Rigidbody2D>(), PlayerTracker.Instance.Player.transform.position);
            ActiveAsteroids++;
        }
    }

}