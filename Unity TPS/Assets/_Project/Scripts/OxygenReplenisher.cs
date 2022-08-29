using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]

public class OxygenReplenisher : MonoBehaviour
{
    private float oxygenReplenish = 20f;

    private void Awake() {
        GetComponent<CapsuleCollider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        var player = other.gameObject.GetComponent<Player>();

        if (player == null) return;

        player.ReplenishOxygen(oxygenReplenish);
        Destroy(gameObject);
    }
}
