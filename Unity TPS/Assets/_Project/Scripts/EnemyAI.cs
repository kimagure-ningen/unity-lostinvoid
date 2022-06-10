using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject gameMaster;
    private GameMaster masterScript;

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

        gameMaster = GameObject.Find("GameMaster");
        if (gameMaster == null)
        {
            Debug.LogError("GameMaster not found.");
        }
        masterScript = gameMaster.GetComponent<GameMaster>();
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
        } else {
            transform.Translate(speed*Time.deltaTime,0,0);
        }
    }

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Obstacle") {
            StartCoroutine(ObstacleCollision());
            Debug.Log("obstacle hit!");
        }
    }

    void EnemyNavigation() {
        transform.LookAt(player.transform, Vector3.up);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 1.5f)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        } else {
            Destroy(gameObject);
            masterScript.spawnedEnemy.RemoveAt(0);
        }
    }

    IEnumerator ObstacleCollision() {
        isHitObstacle = true;
        yield return new WaitForSeconds(0.1f);
        isHitObstacle = false;
    }
}
