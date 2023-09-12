using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAnimationController : MonoBehaviour
{
    ControlHub ch;

    [SerializeField] List<GameObject> leftRotationalThrusters;
    [SerializeField] List<GameObject> rightRotationalThrusters;
    [SerializeField] List<GameObject> forwardThrusters;
    [SerializeField] List<GameObject> reverseThrusters;

    private void Start()
    {
        ch = ControlHub.Instance;

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
    }
}
