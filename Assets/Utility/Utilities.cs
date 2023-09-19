using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Vector3 world position outside the view of <paramref name="cam"/> </returns>
    public static Vector3 GetRandomPosOffScreen(Camera cam)
    {

        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);
        x += Mathf.Sign(x);
        y += Mathf.Sign(y);
        Vector3 randomPoint = new(x, y);

        randomPoint.z = 5f; // set this to whatever you want the distance of the point from the camera to be. Default for a 2D game would be 10.
        Vector3 worldPoint = cam.ViewportToWorldPoint(randomPoint);

        return worldPoint;
    }

    /// <summary>
    /// Checks if <paramref name="gameObject"/> is outside the view of <paramref name="cam"/>
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="gameObject"></param>
    /// <returns></returns>
    public static bool CheckOffScreen(Camera cam, GameObject gameObject)
    {
        Vector2 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.x < 0 ||
            screenPos.x > cam.pixelWidth ||
            screenPos.y < 0 ||
            screenPos.y > cam.pixelWidth)
        {
            return true;
        }
        else return false;
    }

    public static void LoopOffScreen(Camera cam, Rigidbody2D rb, bool hasEnteredScreen)
    {
        GameObject gameObject = rb.gameObject;
        if (CheckOffScreen(cam, gameObject) && hasEnteredScreen)
        {
            hasEnteredScreen = false;
            rb.velocity = rb.velocity;
            rb.angularVelocity = rb.angularVelocity;
            rb.MovePosition(-gameObject.transform.position);
        }
    }
}
