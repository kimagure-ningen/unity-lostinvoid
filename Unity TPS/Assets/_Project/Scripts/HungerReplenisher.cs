using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]

public class HungerReplenisher : MonoBehaviour
{
    private float rotateSpeed = 20f;
    private float hungerReplenish = 20f;

    private void Awake()
    {
        GetComponent<CapsuleCollider>().isTrigger = true;
    }

    private void Update()
    {
        transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        var player = other.gameObject.GetComponent<Player>();

        if (player == null) return;

        player.ReplenishHunger(hungerReplenish);
        Destroy(gameObject);
    }
}
