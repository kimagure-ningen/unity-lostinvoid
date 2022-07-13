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

        gameMaster = GameObject.Find("GameMaster");
        if (gameMaster == null)
        {
            Debug.LogError("GameMaster not found.");
        }
        masterScript = gameMaster.GetComponent<GameMaster>();
    }

    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);

        masterScript.GroundConrol(gameObject, distanceToGround, groundNormal, onGround, rb);
    }
    private IEnumerator BulletRange()
    {
        yield return new WaitForSeconds(bulletRangeTime);
        Destroy(gameObject);
    }
}
