using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerButton : MonoBehaviour
{
    private Player player;
    private Inventory inventory;
    private float hungerReplenish = 20f;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }

    public void EatHamburger()
    {
        player.ReplenishHunger(hungerReplenish);
        Destroy(gameObject);
    }
}
