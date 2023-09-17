using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    Camera cam;

    [Header("Shake")]
    public float duration;
    [Range(0, 1)] public float strength;
    public int vibrato;
    public float randomness;
    private bool isShaking;

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

        cam = Camera.main;
    }

    [ContextMenu("Shake")]
    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    public void ShakeCamera(float _duration, float _strength, int _vibrato, float _randomness)
    {
        StartCoroutine(Shake(_duration, _strength, _vibrato, _randomness));
    }

    IEnumerator Shake()
    {
        if (!isShaking)
        {
            isShaking = true;
            cam.transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
            yield return new WaitForSeconds(duration);
            isShaking = false;
        }
    }
    IEnumerator Shake(float _duration, float _strength, int _vibrato, float _randomness)
    {
        if (!isShaking)
        {
            isShaking = true;
            cam.transform.DOShakePosition(duration, strength, vibrato, randomness, false, true);
            yield return new WaitForSeconds(duration);
            isShaking = false;
        }
    }

}
