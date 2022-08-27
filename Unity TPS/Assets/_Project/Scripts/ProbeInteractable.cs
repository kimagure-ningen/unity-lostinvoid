using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ProbeInteractable : MonoBehaviour
{
    public GameObject probeInteractionCanvas;
    public CinemachineVirtualCamera vCam3;
    private int defaultPriority;

    private void Start()
    {
        defaultPriority = vCam3.Priority;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            probeInteractionCanvas.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                vCam3.Priority = 30;
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
