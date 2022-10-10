using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform princess;
    public float cameraDistance = 30.0f;

    private void FixedUpdate()
    {
        transform.position = new Vector3(princess.position.x, princess.position.y, transform.position.z);
    }
}
