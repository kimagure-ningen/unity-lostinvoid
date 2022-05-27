using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject sphere;
    private GameObject player;
    private float speed = 5f;
    private float gravity = 100f;
    private bool onGround = false;
    private float distanceToGround;
    private Vector3 groundNormal;
    private Rigidbody rb;

    void Start()
    {
        sphere = GameObject.Find("Sphere");
        if (sphere == null)
        {
            Debug.Log("Sphere not found.");
        }

        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Player not found.");
        }

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //* Ground Control
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            distanceToGround = hit.distance;
            groundNormal = hit.normal;

            if (distanceToGround <= 0.2f)
            {
                onGround = true;
            }
            else
            {
                onGround = false;
            }
        }

        //* Gravity & Rotation
        Vector3 gravDirection = (transform.position - sphere.transform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;

        //* Navigation
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 5f)
        {
            transform.LookAt(player.transform, Vector3.up);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}
