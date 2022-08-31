using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ProbeInventory : MonoBehaviour
{
    [Header("Unity Stuff")]
    public CinemachineVirtualCamera vCam3;
    public GameObject spotLight;
    public Inventory inventory;
    public GameObject screenCanvas;

    [Header("Oxygen Tank")]
    private int defaultOxygentankStock = 20;
    private int oxygentankStock;
    public Text oxygentankStockText;
    public GameObject oxygentankItem;

    [Header("Hamburger")]
    private int defaulthamburgerStock = 15;
    private int hamburgerStock;
    public Text hamburgerStockText;
    public GameObject hamburgerItem;

    private void Start()
    {
        oxygentankStock = defaultOxygentankStock;
        oxygentankStockText.text = defaultOxygentankStock + "/" + defaultOxygentankStock;

        hamburgerStock = defaulthamburgerStock;
        hamburgerStockText.text = defaulthamburgerStock + "/" + defaulthamburgerStock;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            EButton();
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            QButton();
        }

        oxygentankStockText.text = oxygentankStock + "/" + defaultOxygentankStock;
        hamburgerStockText.text = hamburgerStock + "/" + defaulthamburgerStock;
    }

    public void ExitButton()
    {
        vCam3.Priority = 5;
        Cursor.visible = false;
        screenCanvas.SetActive(true);
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
    
    public void OxygenTankBuy()
    {
        if (oxygentankStock > 0)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    oxygentankStock--;
                    inventory.isFull[i] = true;
                    Instantiate(oxygentankItem, inventory.slots[i].transform, false);
                    break;
                } 
            }
        }
    }

    public void HamburgerBuy()
    {
        if (hamburgerStock > 0)
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    hamburgerStock--;
                    inventory.isFull[i] = true;
                    Instantiate(hamburgerItem, inventory.slots[i].transform, false);
                }
            }
        }
    }
}
