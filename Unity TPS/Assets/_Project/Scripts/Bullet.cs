using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    private float gravity = 100f;
    private Vector3 groundNormal;
    private Rigidbody rb;
}
