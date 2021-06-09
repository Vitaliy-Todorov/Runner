using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionToTrack : MonoBehaviour
{
    Vector3 swap = new Vector3(0, 0, 2);
    int tracks = 3;

    public void Swap(float y)
    {
        if (y > 0)
            Left();
        if (y < 0)
            Right();
    }

    void Right()
    {
        if (tracks < 3)
        {
            tracks++;
            transform.position -= swap;
        }
    }

    void Left()
    {
        if (tracks > 1)
        {
            tracks--;
            transform.position += swap;
        }
    }
}
