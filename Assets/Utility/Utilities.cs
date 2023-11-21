using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// A collection of helper functions used in various places
/// </summary>
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
    public static bool CheckOffScreen(Camera cam, GameObject gameObject, out ExitStatus exitStatus)
    {
        // Get the screen position of gameObject
        Vector2 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);

        // Check the position vs the edge of the screen bounds & set set exit status
        if (screenPos.x < 0)
        {
            exitStatus = ExitStatus.Left;
            return true;
        }
        else if (screenPos.x > cam.pixelWidth)
        {
            exitStatus = ExitStatus.Right;
            return true;
        }
        else if (screenPos.y < 0)
        {
            exitStatus = ExitStatus.Bottom;
            return true;
        }
        else if (screenPos.y > cam.pixelHeight)
        {
            exitStatus = ExitStatus.Top;
            return true;
        }
        else {
            exitStatus = ExitStatus.OnScreen;
            return false;
        }
    }

    /// <summary>
    /// Uses <see cref="CheckOffScreen(Camera, GameObject, out ExitStatus)"/>'s <see cref="ExitStatus"/> to position the Rigidbody2D to the opposite side of the screen.
    /// </summary>
    /// <param name="cam"></param>
    /// <param name="rb"></param>
    /// <param name="hasEnteredScreen"></param>
    public static void LoopOffScreen(Camera cam, Rigidbody2D rb, ref bool hasEnteredScreen) // Pass by reference for static methods!
    {
        Vector2 screenPos = cam.WorldToScreenPoint(rb.gameObject.transform.position);
        ExitStatus exitStatus;
        GameObject gameObject = rb.gameObject;
        if (CheckOffScreen(cam, gameObject, out exitStatus) && hasEnteredScreen)
        {
            Vector3 rbPos = cam.WorldToScreenPoint(rb.position);

            switch (exitStatus)
            {
                case ExitStatus.Left:
                    rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, rbPos.y)));
                    Debug.Log("Exited X", gameObject);
                    hasEnteredScreen = false;
                    break;
                case ExitStatus.Right:
                    rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(0, rbPos.y)));
                    Debug.Log("Exited Y", gameObject);
                    hasEnteredScreen = false;
                    break;
                case ExitStatus.Top:
                    rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(rbPos.x, 0)));
                    Debug.Log("Exited Y", gameObject);
                    hasEnteredScreen = false;
                    break;
                case ExitStatus.Bottom:
                    rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(rbPos.x, cam.pixelHeight)));
                    Debug.Log("Exited Y", gameObject);
                    hasEnteredScreen = false;
                    break;
                default:
                    Debug.Log("How did we get here?");
                    break;

            }
        }
    }

    public static Vector3 GetPointOnEdgeOfScreen(Camera cam)
    {
        Vector3[] frustumCorners = new Vector3[4];
        cam.CalculateFrustumCorners(new Rect(0, 0, 1, 1), cam.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);

        /* CalculateFrustumCorners Output Array Index Guide
       1 ------------ 2
         |          |
         |          |
       0 ------------ 3

         */

        var PickXOrY = Random.Range(0, 1);

        if (PickXOrY == 0)
        {
            var randomXPos = Random.Range(frustumCorners[0].x, frustumCorners[3].x); // 3.x = Lower right corner
            return new Vector3(randomXPos, cam.ScreenToWorldPoint(frustumCorners[0]).x);
        }
        else
        {
            var randomYPos = Random.Range(frustumCorners[0].y, frustumCorners[1].y); //1.y = Upper Left Corner
            return new Vector3(cam.ScreenToWorldPoint(frustumCorners[0]).y, randomYPos);
        }
    }
}

public enum ExitStatus
{
    OnScreen,
    Top,
    Bottom,
    Left,
    Right
}
