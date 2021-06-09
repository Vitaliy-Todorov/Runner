using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTrack : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    Vector3 direction = new Vector3(-1, 0, 0);

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
    }
}
