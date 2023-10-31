using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singleton class to provide a reference to the player
/// </summary>
public class PlayerTracker : MonoBehaviour
{
    public static PlayerTracker Instance;
    [SerializeField] private GameObject player; 
    [SerializeField] private Rigidbody2D playerRB; 
    public GameObject Player { get { return player; } }
    public Rigidbody2D PlayerRB { get { return playerRB; } }

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
}
