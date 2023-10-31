using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Singleton Class to Capture Inputs
/// </summary>
public class ControlHub : MonoBehaviour
{
    public static ControlHub Instance { get; private set; }

    #region Control Events
    public UnityEvent forwardInput;
    public UnityEvent boostInput;
    public UnityEvent backwardInput;
    public UnityEvent leftInput;
    public UnityEvent rightInput;
    public UnityEvent fireInput;

    public UnityEvent forwardReleasedInput;
    public UnityEvent boostReleasedInput;
    public UnityEvent backwardReleasedInput;
    public UnityEvent leftReleasedInput;
    public UnityEvent rightReleasedInput;

    public UnityEvent upScrollInput;
    public UnityEvent downScrollInput;
    #endregion

    private void Awake()
    {
        // Create singleton
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    void Update()
    {
        #region Input.GetKey
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            boostInput.Invoke();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            fireInput.Invoke();
        }
        #endregion
        #region Input.GetKeyUp
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
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boostReleasedInput.Invoke();
        }
        #endregion
        #region Axes
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            upScrollInput.Invoke();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            downScrollInput.Invoke();
        }
        #endregion
    }
}
