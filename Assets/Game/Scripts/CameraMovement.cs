using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothing = 5f;
   [SerializeField] private Vector3 offset;

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {

        Vector3 targetCamPos = new Vector3(target.position.x, target.position.y,0) + offset;
        transform.position = Vector3.Lerp(transform.position,
                                           targetCamPos,
                                           smoothing * Time.fixedDeltaTime);
    }
}
