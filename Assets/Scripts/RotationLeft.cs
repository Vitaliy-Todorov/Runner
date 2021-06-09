using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLeft : MonoBehaviour
{
    [SerializeField]
    float speed;

    public bool rotate;

    private void OnTriggerEnter(Collider other)
    {
        rotate = true;
    }

    private void FixedUpdate()
    {
        if (rotate)
        {
            transform.root.RotateAround(transform.position, Vector3.up, -1 * speed * Time.fixedDeltaTime);
            //transform.root.Rotate(direction * speed * Time.fixedDeltaTime);
        }
    }
}
