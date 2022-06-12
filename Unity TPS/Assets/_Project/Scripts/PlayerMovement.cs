using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameMaster;
    private GameMaster masterScript;
    public GameObject planet;
    private float speed = 4f;
    private float jumpHeight = 1.2f;
    private float gravity = 100f;
    private bool onGround = false;
    private float distanceToGround;
    private Vector3 groundNormal;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        masterScript = gameMaster.GetComponent<GameMaster>();
    }

    void Update()
    {
        //* Movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);

        //* Local Rotation
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 40000 * jumpHeight * Time.deltaTime);
        }

        //* masterScript.GroundConrol(gameObject, distanceToGround, groundNormal, onGround);
        //* masterScript.Gravity(gameObject,onGround, rb, groundNormal);

        GroundConrol();
        Gravity();
    }

    void GroundConrol() {
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
    }

    void Gravity() {
        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }
}
