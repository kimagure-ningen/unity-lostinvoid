using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Camera")]
    public CinemachineVirtualCamera vCam2;
    private int defaultPriority;
    public bool isShootingMode = false;

    [Header("Aim")]
    public Transform character;
    public Transform pivot;
    public GameObject crosshair;
    [Range(-0.999f, -0.5f)]
    public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)]
    public float minYAngle = 0.5f;

    [Header("Gravity & GroundControl")]
    public GameObject planet;
    private float gravity = 100f;

    [Header("Enemy")]
    public GameObject enemy;
    public List<GameObject> spawnedEnemy;

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        defaultPriority = vCam2.Priority;

        spawnedEnemy = new List<GameObject>();
    }

    private void Update() {
        SwitchCamera();

        MouseAim();

        if (spawnedEnemy.Count < 1) {
            spawnedEnemy.Add(Instantiate(enemy, new Vector3(0,0,22), Quaternion.identity));
        }
    }

    public void GroundConrol(GameObject _gameObject, float distanceToGround, Vector3 groundNormal, bool onGround, Rigidbody rb) {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(_gameObject.transform.position, -_gameObject.transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;

            if (distanceToGround <= 0.2f)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }
        
        Gravity(_gameObject, onGround, rb, groundNormal);
    }

    private void Gravity(GameObject _gameObject, bool onGround, Rigidbody rb, Vector3 groundNormal) {
        Vector3 gravDirection = (_gameObject.transform.position - planet.transform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }
        Quaternion toRotation = Quaternion.FromToRotation(_gameObject.transform.up, groundNormal) * _gameObject.transform.rotation;
        _gameObject.transform.rotation = toRotation;
    }

    private void SwitchCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (vCam2.Priority == 20)
            {
                vCam2.Priority = defaultPriority;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                crosshair.SetActive(false);
                isShootingMode = false;
            }
            else
            {
                vCam2.Priority = 20;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                crosshair.SetActive(true);
                isShootingMode = true;
            }
        }
    }

    private void MouseAim()
    {
        if (vCam2.Priority == 20)
        {
            float xRotation = Input.GetAxis("Mouse X");
            float yRotation = Input.GetAxis("Mouse Y");

            character.transform.Rotate(0, xRotation, 0);

            float currentAngle = pivot.transform.localRotation.x;

            pivot.transform.Rotate(-yRotation, 0, 0);

            //if (-yRotation != 0)
            //{
            //    if (0 < yRotation)
            //    {
            //        if (minYAngle <= currentAngle)
            //        {
            //            pivot.transform.Rotate(-yRotation, 0, 0);
            //            Debug.Log("Turning");
            //        }
            //    }
            //    else
            //    {
            //        if (currentAngle <= maxYAngle)
            //        {
            //            pivot.transform.Rotate(-yRotation, 0, 0);
            //        }
            //    }
            //}
        }
    }

}
