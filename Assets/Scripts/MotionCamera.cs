using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCamera : MonoBehaviour
{
    [SerializeField]
    Transform _�haracter;
    [SerializeField]
    Vector3 _distanceToCamera;

    float smooth = 5.0f;
    float offset = 7.0f;

    private void FixedUpdate()
    {
        //transform.position = _�haracter.transform.position + _distanceToCamera;
        transform.position = Vector3.Lerp(transform.position, _�haracter.transform.position + _distanceToCamera + _�haracter.GetComponent<Rigidbody>().velocity.normalized * offset, smooth * Time.deltaTime);
    }
}
