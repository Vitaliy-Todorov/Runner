using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MovingAlongCurve : MonoBehaviour
{
    List<Transform> _curve = new List<Transform>();

    [SerializeField]
    [Range(0,1)]
    float t;
    [SerializeField]
    float scond;
    int time;

    public List<Transform> Curve { get => _curve; set => _curve = value; }

    private void OnTriggerEnter(Collider other)
    {
        time = 0;
    }

    private void FixedUpdate()
    {
        time++;
        transform.position = Bezier.GetPoint(_curve[0].position, _curve[1].position, _curve[2].position, _curve[3].position, ((float)time / 50)/ scond);
        transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(_curve[0].position, _curve[1].position, _curve[2].position, _curve[3].position, (time / 50) / scond));

    }
}
