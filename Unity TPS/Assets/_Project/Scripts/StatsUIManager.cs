using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUIManager : MonoBehaviour
{
    public Player _player;
    public Text healthMeter;
    public Text hungerMeter;
    public Text oxygenMeter;
    public GameObject statsPanel;

    private bool isBarOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (isBarOpen == false)
            {
                statsPanel.SetActive(true);
                isBarOpen = true;
            }
            else
            {
                statsPanel.SetActive(false);
                isBarOpen = false;
            }
        }
    }

    private void FixedUpdate() {
        healthMeter.text = "Health: " + Mathf.Floor(_player.currentHealth).ToString();
        hungerMeter.text = "Hunger: " + Mathf.Floor(_player.currentHunger).ToString();
        oxygenMeter.text = "Oxygen: " + Mathf.Floor(_player.currentOxygen).ToString();
    }
}
