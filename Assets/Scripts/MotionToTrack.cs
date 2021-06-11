using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionToTrack : MonoBehaviour
{
    int tracks = 1;

    MovingAlongCurve movingAlongCurve;
    List<Transform>[] _curves;

    private void Start()
    {
        _curves = new List<Transform>[3];
    }

    private void OnTriggerEnter(Collider other)
    {
        Tile tile = other.gameObject.GetComponent<Tile>();
        if(tile != null)
        {
            _curves[0] = tile.curve1;
            _curves[1] = tile.curve2;
            _curves[2] = tile.curve3;
        }

        movingAlongCurve = gameObject.GetComponent<MovingAlongCurve>();
        movingAlongCurve.Curve = _curves[tracks];
    }

    public void Swap(float y)
    {
        if (y > 0)
            Left();
        if (y < 0)
            Right();
    }

    void Right()
    {
        if (tracks < 2)
        {
            tracks++;
            movingAlongCurve.Curve = _curves[tracks];
        }
    }

    void Left()
    {
        if (tracks > 0)
        {
            tracks--;
            movingAlongCurve.Curve = _curves[tracks];
        }
    }
}
