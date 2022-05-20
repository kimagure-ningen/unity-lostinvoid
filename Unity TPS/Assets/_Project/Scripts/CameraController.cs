using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float angleUp = 60f;
    float angleDown = -60f;
    float rotate_speed = 1;
    public Vector3 axisPos;

    void Update()
    {
        transform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * rotate_speed,
            Input.GetAxis("Mouse X") * rotate_speed, 0);

        float angleX = transform.eulerAngles.x;

        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }

        transform.eulerAngles = new Vector3(Mathf.Clamp(angleX, angleDown, angleUp), transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
