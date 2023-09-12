using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlHub : MonoBehaviour
{
    public static ControlHub Instance { get; private set; }

    public UnityEvent forwardInput;
    public UnityEvent backwardInput;
    public UnityEvent leftInput;
    public UnityEvent rightInput;
    public UnityEvent fireInput;

    public UnityEvent forwardReleasedInput;
    public UnityEvent backwardReleasedInput;
    public UnityEvent leftReleasedInput;
    public UnityEvent rightReleasedInput;

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

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            forwardInput.Invoke();
        }
        if (Input.GetKey(KeyCode.S))
        {
            backwardInput.Invoke();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rightInput.Invoke();
        }
        if (Input.GetKey(KeyCode.A))
        {
            leftInput.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireInput.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            forwardReleasedInput.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            backwardReleasedInput.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rightReleasedInput.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            leftReleasedInput.Invoke();
        }
    }
}
