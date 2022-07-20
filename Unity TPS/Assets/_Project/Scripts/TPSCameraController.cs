using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCameraController : MonoBehaviour
{
    public Transform character;
    public Transform pivot;

    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;

    void Update()
    {
        float xRotation = Input.GetAxis("Mouse X");
        float yRotation = Input.GetAxis("Mouse Y");

        character.transform.Rotate(0, xRotation, 0);

        float currentAngle = pivot.transform.localRotation.x;
        
        if (-yRotation != 0)
        {
            if (0 < yRotation)
            {
                if (minYAngle <= currentAngle)
                {
                    pivot.transform.Rotate(-yRotation, 0, 0);
                }
            }
            else
            {
                if (currentAngle <= maxYAngle)
                {
                    pivot.transform.Rotate(-yRotation, 0, 0);
                }
            }
        }
    }
}
