using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject planet;
    private GameObject player;
    private float speed = 5f;
    private float gravity = 100f;
    private bool onGround = false;
    private float distanceToGround;
    private Vector3 groundNormal;
    private Rigidbody rb;

    private bool isHitObstacle = false;

    void Start()
    {
        planet = GameObject.Find("planetTest");
        if (planet == null)
        {
            Debug.LogError("Planet not found.");
        }

        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Player not found.");
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
        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;

        if (isHitObstacle == false){
            EnemyNavigation();
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Obstacle") {
            StartCoroutine(ObstacleCollision());
            Debug.Log("obstacle hit!");
        }
    }

    void EnemyNavigation() {
        transform.LookAt(player.transform, Vector3.up);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 5f)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    IEnumerator ObstacleCollision() {
        isHitObstacle = true;
        //! fix here (it's not in update method)
        transform.Translate(0,0, -speed);
        yield return new WaitForSeconds(1);
        transform.Translate(speed *Time.deltaTime,0,0);
        yield return new WaitForSeconds(1);
        isHitObstacle = false;
    }
}
