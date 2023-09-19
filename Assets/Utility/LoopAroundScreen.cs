using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LoopAroundScreen : MonoBehaviour
{
    Camera cam;
    Rigidbody2D rb;
    public bool hasEnteredScreen = false;
    [SerializeField] float screenXBoundOffset = 0.5f;
    [SerializeField] float screenYBoundOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Utilities.CheckOffScreen(cam, gameObject, screenXBoundOffset, screenYBoundOffset, out ExitStatus exitStatus) == false)
        {
            hasEnteredScreen = true;
        }
        Utilities.LoopOffScreen(cam, rb, hasEnteredScreen);
    }
}
