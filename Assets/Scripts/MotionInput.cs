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
            downPosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            upPosition = Input.mousePosition;
            ClickUp();
        }

        if (!(Input.touchCount > 0))
            return;

        Touch touch = Input.GetTouch(0);

        switch (Input.GetTouch(0).phase)
        {
            case TouchPhase.Began:
                downPosition = touch.position;
                break;

            case TouchPhase.Ended:
                upPosition = touch.position;
                ClickUp();
                break;
        }
    }

    Vector2 ClickPosition()
    {
        //return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Input.mousePosition;
    }

    void ClickUp()
    {
        offsetY = upPosition.y - downPosition.y;
        motionRoad.Swap(offsetY);
    }
}
