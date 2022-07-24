using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Unity Stuff")]
    public GameMaster gameMaster;
    public Player player;
    public GameObject planet;
    public GameObject playerMesh;

    private float speed = 4f;
    private float jumpHeight = 1.2f;
    private bool onGround = false;
    private float distanceToGround;
    private Vector3 groundNormal;
    private Rigidbody rb;

    // Testing
    public Transform orientation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //* Movement
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, z);

        // Testing New Type of Movement
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        //rb.AddForce(orientation.transform.forward * y * 2000 * Time.deltaTime);
        //rb.AddForce(orientation.transform.right * x * 2000 * Time.deltaTime);

        //* Jump (Not Working)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * 100000 * jumpHeight * Time.deltaTime);
        }

        gameMaster.GroundConrol(gameObject, distanceToGround, groundNormal, onGround, rb);

        meshController();
    }

    private void meshController() {
        if (player.isShootingMode == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, -90, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, 90, 0);
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, -45, 0);
            }

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, 45, 0);
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, -135, 0);
            }

            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                playerMesh.transform.localRotation = Quaternion.Euler(0, 135, 0);
            }
        }
    }
}
