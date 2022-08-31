using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ProbeInteractable : MonoBehaviour
{
    public Player player;
    public GameObject ProbeInventory;
    public GameObject probeInteractionCanvas;
    public CinemachineVirtualCamera vCam3;
    public GameObject screenCanvas;
    private int defaultPriority;

    private void Start()
    {
        defaultPriority = vCam3.Priority;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered");

        if (other.gameObject.tag == "Player")
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            probeInteractionCanvas.SetActive(false);
        }
    }
}
