using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamageable : Damageable
{
    public override void Destroy()
    {
        base.Destroy();
        AsteroidSpawner.Instance.ActiveAsteroids--;
    }
}
