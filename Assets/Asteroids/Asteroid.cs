using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Camera cam;
    bool hasEnteredScreen = false;
    [SerializeField] float damage = 5; 

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(CheckOffScreen() == false)
        {
            hasEnteredScreen = true;
        }

        DestroyOffScreen();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (collision.collider.TryGetComponent<Damageable>(out Damageable damageable))
                damageable.Damage(damage);
        }
    }

    bool CheckOffScreen()
    {
        Vector2 screenPos = cam.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 ||
            screenPos.x > cam.pixelWidth ||
            screenPos.y < 0 ||
            screenPos.y > cam.pixelWidth)
        {
            return true;
        }
        else return false;
    }

    void DestroyOffScreen()
    {
        if(CheckOffScreen() && hasEnteredScreen)
        {
            Destroy(gameObject);
        }
    }
}
