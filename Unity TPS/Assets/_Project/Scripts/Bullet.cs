using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidbody;

    private float bulletSpeed = 40f;
    private float bulletRangeTime = 0.75f;
    private float bulletDamage = 20f;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;

        StartCoroutine(BulletRange());
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
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
