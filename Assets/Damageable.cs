using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] UnityEvent onDeath;
    public float health;
    public void Damage(float damageAmount)
    {
        if (health <= damageAmount)
        {
            Destroy();
        }
        else
        {
            health -= damageAmount;
        }
    }

    public void Destroy()
    {
        Debug.Log("Destroyed" + gameObject.name, gameObject);
        onDeath.Invoke();
    }
}
