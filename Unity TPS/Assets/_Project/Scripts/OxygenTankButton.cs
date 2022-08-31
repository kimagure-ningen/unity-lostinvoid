using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTankButton : MonoBehaviour
{
    private Player player;
    private Inventory inventory;
    private float oxygenReplenish = 20f;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void UseOxygenTank()
    {
        player.ReplenishOxygen(oxygenReplenish);
        Destroy(gameObject);
    }
}
