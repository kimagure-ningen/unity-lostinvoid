using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsUIManager : MonoBehaviour
{
    [Header("Unity Stuff")]
    public Player player;

    public Slider oxygenBar;
    public TextMeshProUGUI oxygenPercent;
    public Slider hungerBar;
    public TextMeshProUGUI hungerPercent;

    private void Start()
    {
        oxygenBar.maxValue = player.maxOxygen;
        hungerBar.maxValue = player.maxHunger;
    }

    private void FixedUpdate()
    {
        oxygenBar.value = player.currentOxygen;
        oxygenPercent.text = Mathf.Floor(player.currentOxygen / player.maxOxygen * 100).ToString() + "%";
        hungerBar.value = player.currentHunger;
        hungerPercent.text = Mathf.Floor(player.currentHunger / player.maxHunger * 100).ToString() + "%";
    }
}
