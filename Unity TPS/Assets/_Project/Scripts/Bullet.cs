using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject planet;
    private float bulletSpeed = 20f;
    private float gravity = 100f;
    private float bulletRangeTime = 0.75f;
    private bool onGround = false;
    private float distanceToGround;
    private Vector3 groundNormal;
    private Rigidbody rb;

    void Start()
    {
        planet = GameObject.Find("planetTest");
        if (planet == null)
        {
            Debug.LogError("Planet not found.");
        }

        StartCoroutine(BulletRange());

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);

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
        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }
    private IEnumerator BulletRange()
    {
        yield return new WaitForSeconds(bulletRangeTime);
        Destroy(gameObject);
    }
}
