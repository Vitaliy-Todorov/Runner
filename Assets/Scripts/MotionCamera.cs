using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionCamera : MonoBehaviour
{
    [SerializeField]
    Transform _ñharacter;
    [SerializeField]
    Vector3 _distanceToCamera;

    float smooth = 5.0f;
    float offset = 7.0f;

    private void FixedUpdate()
    {
        //transform.position = _ñharacter.transform.position + _distanceToCamera;
        transform.position = Vector3.Lerp(transform.position, _ñharacter.transform.position + _distanceToCamera + _ñharacter.GetComponent<Rigidbody>().velocity.normalized * offset, smooth * Time.deltaTime);
    }
}
