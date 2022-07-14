using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class OxygenReplenisher : MonoBehaviour
{
    private void Awake() {
        GetComponent<SphereCollider>().isTrigger = true;
    }
}
