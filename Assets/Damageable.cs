using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public virtual void Destroy()
    {
        Debug.Log("Destroyed" + gameObject.name, gameObject);
        OnDeath.Invoke();
        if(gameObject.layer != LayerMask.NameToLayer("Player")) // Prevent the player being disabled.
        CameraShake.Instance.ShakeCamera();
    }
    private void Update()
    {
        if (markedForDeath)
            DisableAfterDuration(duration);
    }
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
