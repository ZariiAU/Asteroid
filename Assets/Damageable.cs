using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Attach to any gameObject that can take damage
/// </summary>
public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] public UnityEvent OnDeath;
    [SerializeField] private bool markedForDeath = false; // Used to stop
    private float elapsedTime = 0;
    private float duration = 1;
    public float health;

    public void Damage(float damageAmount)
    {
        if (health <= damageAmount)
            Destroy();
        else
            health -= damageAmount;
    }

    /// <summary>
    /// Virtual function to provide hooks into the death sequence of an object
    /// Calls <see cref="OnDeath"/> and shakes the screen
    /// </summary>
    public virtual void Destroy()
    {
        Debug.Log("Destroyed" + gameObject.name, gameObject);
        OnDeath.Invoke();
        
        CameraShake.Instance.ShakeCamera();
    }
    private void Update()
    {
        if (markedForDeath)
            DisableAfterDuration(duration);
    }

    /// <summary>
    /// Method to disable after a duration without a Coroutine
    /// </summary>
    /// <param name="_duration"></param>
    public void DisableAfterDuration(float _duration)
    {
        if (elapsedTime < _duration)
            elapsedTime += Time.deltaTime;
        else
        {
            elapsedTime = 0;
            gameObject.SetActive(false);
        }
    }
}
