using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float xSpeed = 3.5f;
    private float sensitivity = 17f;

    private float minFov = 35f;
    private float maxFov = 100f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * xSpeed);
            transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * xSpeed);
        }

        //* Zoom
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
