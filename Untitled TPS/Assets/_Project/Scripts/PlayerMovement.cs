using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject planet;

    float speed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -1f, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 1f, 0);
        }


        Vector3 ground = planet.transform.position - this.transform.position;
        Physics.gravity = ground * 9.81f;
    }
}
