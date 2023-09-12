using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
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
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
