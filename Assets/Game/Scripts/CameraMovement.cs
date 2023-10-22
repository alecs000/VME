using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {

        Vector3 targetCamPos = new Vector3(target.position.x, 0, -1.44f) + offset;
        transform.position = Vector3.Lerp(transform.position,
                                           targetCamPos,
                                           smoothing * Time.fixedDeltaTime);
    }
}
