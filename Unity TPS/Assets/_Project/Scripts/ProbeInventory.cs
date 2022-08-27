using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeInventory : MonoBehaviour
{
    public GameObject vCam3;
    public GameObject spotLight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (vCam3.transform.position.x < 40 || spotLight.transform.position.x < 40)
            {
                vCam3.transform.Translate(10, 0, 0);
                spotLight.transform.Translate(10, 0, 0);
            }
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (vCam3.transform.position.x > -40 || spotLight.transform.position.x > -40)
            {
                vCam3.transform.Translate(-10, 0, 0);
                spotLight.transform.Translate(-10, 0, 0);
            }
        }
    }
}
