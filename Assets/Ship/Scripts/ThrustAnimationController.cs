using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ThrustAnimationController : MonoBehaviour
{
    ControlHub ch;

    [SerializeField] List<GameObject> leftRotationalThrusters;
    [SerializeField] List<GameObject> rightRotationalThrusters;
    [SerializeField] List<GameObject> forwardThrusters;
    [SerializeField] List<GameObject> reverseThrusters;
    [SerializeField] List<GameObject> boostForwardThrusters;

    private void Start()
    {
        ch = ControlHub.Instance;

        // Pressed Input
        ch.forwardInput.AddListener(() => { 
            foreach(GameObject thruster in forwardThrusters)
                {
                    thruster.SetActive(true);
                }
        });
        ch.rightInput.AddListener(() => {
            foreach (GameObject thruster in rightRotationalThrusters)
            {
                thruster.SetActive(true);
            }
        });
        ch.leftInput.AddListener(() => {
            foreach (GameObject thruster in leftRotationalThrusters)
            {
                thruster.SetActive(true);
            }
        });
        ch.backwardInput.AddListener(() => {
            foreach (GameObject thruster in reverseThrusters)
            {
                thruster.SetActive(true);
            }
        });
        ch.boostInput.AddListener(() => {
            foreach (GameObject thruster in boostForwardThrusters)
            {
                thruster.SetActive(true);
            }
        });

        // Released Input
        ch.forwardReleasedInput.AddListener(() => {
            foreach (GameObject thruster in forwardThrusters)
            {
                thruster.SetActive(false);
            }
        });
        ch.rightReleasedInput.AddListener(() => {
            foreach (GameObject thruster in rightRotationalThrusters)
            {
                thruster.SetActive(false);
            }
        });
        ch.leftReleasedInput.AddListener(() => {
            foreach (GameObject thruster in leftRotationalThrusters)
            {
                thruster.SetActive(false);
            }
        });
        ch.backwardReleasedInput.AddListener(() => {
            foreach (GameObject thruster in reverseThrusters)
            {
                thruster.SetActive(false);
            }
        });
        ch.boostReleasedInput.AddListener(() => {
            foreach (GameObject thruster in boostForwardThrusters)
            {
                thruster.SetActive(false);
            }
        });
    }
}
