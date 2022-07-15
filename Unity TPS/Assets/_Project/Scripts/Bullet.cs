using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject gameMaster;
    private GameMaster masterScript;
    private GameObject planet;
    private float bulletSpeed = 20f;
    private float bulletRangeTime = 0.75f;
    private float bulletDamage = 20f;
    private bool onGround = false;
    private float distanceToGround;
    private Vector3 groundNormal;
    private Rigidbody rb;

    private void Start()
    {
        planet = GameObject.Find("planetTest");
        if (planet == null)
        {
            Debug.LogError("Planet not found.");
        }

        StartCoroutine(BulletRange());

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        gameMaster = GameObject.Find("GameMaster");
        if (gameMaster == null)
        {
            Debug.LogError("GameMaster not found.");
        }
        masterScript = gameMaster.GetComponent<GameMaster>();
    }

    private void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);

        masterScript.GroundConrol(gameObject, distanceToGround, groundNormal, onGround, rb);
    }
    private IEnumerator BulletRange()
    {
        yield return new WaitForSeconds(bulletRangeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            var enemyScript = other.gameObject.GetComponent<Enemy>();
            if (enemyScript == null) return;

            enemyScript.Damage(bulletDamage);

            Destroy(gameObject);
            // add particles when hit
        } else if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            // maybe spawn particles
        }
    }
}
