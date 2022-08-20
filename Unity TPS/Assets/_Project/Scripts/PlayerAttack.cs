using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Player player;

    public GameObject shootPoint;
    public GameObject bulletPrefab;

    [Header("Aim")]
    public Transform character;
    public Transform pivot;
    private float maxYAngle = 0.3f;
    private float minYAngle = -0.2f;

    public LayerMask aimColliderLayerMask = new LayerMask();
    public Transform debugTransform;

    void Update()
    {
        MouseAim();

        if (player.isShootingMode == true)
        {
            MouseController();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
        }
    }

    private void MouseAim()
    {
        if (player.vCam2.Priority == 20)
        {
            float xRotation = Input.GetAxis("Mouse X");
            float yRotation = Input.GetAxis("Mouse Y");

            character.transform.Rotate(0, xRotation, 0);

            float currentAngle = pivot.transform.localRotation.x;

            if (-yRotation != 0)
            {
                if (0 < yRotation)
                {
                    if (currentAngle >= minYAngle)
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

    private void MouseController()
    {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        Vector3 worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
    }
}
