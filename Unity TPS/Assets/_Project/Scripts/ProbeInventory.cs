using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ProbeInventory : MonoBehaviour
{
    public CinemachineVirtualCamera vCam3;
    public GameObject spotLight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            EButton();
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            QButton();
        }
    }

    public void ExitButton()
    {
        vCam3.Priority = 5;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }

    public void QButton()
    {
        if (vCam3.transform.position.x > -40 || spotLight.transform.position.x > -40)
        {
            vCam3.transform.Translate(-10, 0, 0);
            spotLight.transform.Translate(-10, 0, 0);
        }
    }

    public void EButton()
    {
        if (vCam3.transform.position.x < 40 || spotLight.transform.position.x < 40)
        {
            vCam3.transform.Translate(10, 0, 0);
            spotLight.transform.Translate(10, 0, 0);
        }
    }
}
