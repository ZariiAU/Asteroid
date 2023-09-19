using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public static bool CheckOffScreen(Camera cam, GameObject gameObject, float screenXBoundOffset, float screenYBoundOffset, out ExitStatus exitStatus)
    {
        Vector2 screenPos = cam.WorldToScreenPoint(gameObject.transform.position);
        if (screenPos.x < 0)
        {
            exitStatus = ExitStatus.Left;
            return true;
        }
        else if (screenPos.x - 0.5f > cam.pixelWidth + 0.5f)
        {
            exitStatus = ExitStatus.Right;
            return true;
        }
        else if (screenPos.y < -0.5f)
        {
            exitStatus = ExitStatus.Bottom;
            return true;
        }
        else if (screenPos.y > cam.pixelWidth + 0.5f)
        {
            exitStatus = ExitStatus.Top;
            return true;
        }
        else {
            exitStatus = ExitStatus.OnScreen;
            return false;
        }
    }

    public static void LoopOffScreen(Camera cam, Rigidbody2D rb, bool hasEnteredScreen)
    {
        Vector2 screenPos = cam.WorldToScreenPoint(rb.gameObject.transform.position);
        ExitStatus exitStatus;
        GameObject gameObject = rb.gameObject;
        if (CheckOffScreen(cam, gameObject, 0.5f, 0.5f, out exitStatus) && hasEnteredScreen)
        {
            if (exitStatus == ExitStatus.Left)
            {
                rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, rb.position.y)));
                Debug.Log("Exited X", gameObject);
                hasEnteredScreen = false;
            }
            else if (exitStatus == ExitStatus.Right)
            {
                rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(0, rb.position.y)));
                Debug.Log("Exited Y", gameObject);
                hasEnteredScreen = false;
            }
            else if (exitStatus == ExitStatus.Top)
            {
                rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(rb.position.x, 0)));
                Debug.Log("Exited Y", gameObject);
                hasEnteredScreen = false;
            }
            else if (exitStatus == ExitStatus.Bottom)
            {
                rb.MovePosition(cam.ScreenToWorldPoint(new Vector2(rb.position.x, cam.pixelHeight)));
                Debug.Log("Exited Y", gameObject);
                hasEnteredScreen = false;
            }
            else
            {
                Debug.Log("How did we get here?");
            }
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
