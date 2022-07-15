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

    private void FixedUpdate() {
        healthMeter.text = "Health: " + Mathf.Floor(_player.currentHealth).ToString();
        hungerMeter.text = "Hunger: " + Mathf.Floor(_player.currentHunger).ToString();
        oxygenMeter.text = "Oxygen: " + Mathf.Floor(_player.currentOxygen).ToString();
    }
}
