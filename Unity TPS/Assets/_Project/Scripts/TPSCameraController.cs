using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TPSCameraController : MonoBehaviour
{
    [Header("Cinemachine Setup")]
    public CinemachineVirtualCamera vCam2;
    private int defaultPriority;

    public Transform character;
    public Transform pivot;

    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;

    private void Start()
    {
        defaultPriority = vCam2.Priority;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (vCam2.Priority == 20)
            {
                vCam2.Priority = defaultPriority;
            } else
            {
                vCam2.Priority = 20;
            }
        }

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
                    Debug.Log("Turning");
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
