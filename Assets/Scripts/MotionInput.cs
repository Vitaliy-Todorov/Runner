using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionInput : MonoBehaviour
{
    Vector3 downPosition;
    Vector3 upPosition;
    float offsetY;

    MotionToTrack motionRoad;

    private void Awake()
    {
        motionRoad = GetComponent<MotionToTrack>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            downPosition = MousePosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            upPosition = MousePosition();
            offsetY = upPosition.y - downPosition.y;
            motionRoad.Swap(offsetY);
        }
    }
    Vector2 MousePosition()
    {
        //return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Input.mousePosition;
    }
}
