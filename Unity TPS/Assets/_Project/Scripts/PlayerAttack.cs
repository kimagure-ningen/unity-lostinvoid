using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Unity Stuff")]
    public Player player;

    public GameObject shootPoint;
    public GameObject bulletPrefab;
    public GameObject gun;
    public Animator animator;

    [Header("Aim")]
    public Transform character;
    public Transform pivot;
    private float maxYAngle = 0.3f;
    private float minYAngle = -0.2f;

    public LayerMask aimColliderLayerMask = new LayerMask();

    void Update()
    {
        MouseAim();

        animator.SetBool("isShootingMode", player.isShootingMode);

        if (player.isShootingMode == true)
        {
            gun.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseWorldPosition = Vector3.zero;

                Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
                Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
                {
                    mouseWorldPosition = raycastHit.point;
                }

                Vector3 aimDir = (mouseWorldPosition - shootPoint.transform.position).normalized;
                Debug.Log(mouseWorldPosition);
                Instantiate(bulletPrefab, shootPoint.transform.position, Quaternion.LookRotation(aimDir, Vector3.up));
            }

        } else
        {
            gun.SetActive(false);
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
}
