using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add this component to any gameObject to make it loop around the edges of the screen
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class LoopAroundScreen : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    public bool hasEnteredScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Utilities.CheckOffScreen(cam, gameObject, out ExitStatus exitStatus) == false)
        {
            hasEnteredScreen = true;
        }
        Utilities.LoopOffScreen(cam, rb, ref hasEnteredScreen);
    }
}
