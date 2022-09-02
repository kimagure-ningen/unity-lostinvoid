using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ProbeInteractable : MonoBehaviour
{
    [Header("Unity Stuff")]
    public GameObject _player;
    public Player player;
    public GameObject ProbeInventory;
    public GameObject probeInteractionCanvas;
    public CinemachineVirtualCamera vCam3;
    public GameObject screenCanvas;
    private int defaultPriority;
    private float UIAppearDistance = 8f;

    private void Start()
    {
        defaultPriority = vCam3.Priority;
    }

    private void Update()
    {
        float distance = Vector3.Distance(_player.transform.position, gameObject.transform.position);

        if (distance <= UIAppearDistance)
        {
            probeInteractionCanvas.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                vCam3.Priority = 30;
                Cursor.visible = true;
                ProbeInventory.SetActive(true);
                screenCanvas.SetActive(false);

                if (player.isShootingMode == true)
                {
                    player.SwitchCamera();
                }
            }
        } else
        {
            probeInteractionCanvas.SetActive(false);
        }
    }
}
