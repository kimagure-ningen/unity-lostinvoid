using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [Header("Gravity & GroundControl")]
    public GameObject planet;
    private float gravity = 100f;

    [Header("Enemy")]
    public GameObject enemy;
    public List<GameObject> spawnedEnemy;

    private void Start() {
        spawnedEnemy = new List<GameObject>();
    }

    private void Update() {
        if (spawnedEnemy.Count < 1) {
            spawnedEnemy.Add(Instantiate(enemy, new Vector3(0,0,22), Quaternion.identity));
        }
    }

    public void GroundConrol(GameObject _gameObject, float distanceToGround, Vector3 groundNormal, bool onGround, Rigidbody rb) {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(_gameObject.transform.position, -_gameObject.transform.up, out hit, 10))
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
        
        Gravity(_gameObject, onGround, rb, groundNormal);
    }

    private void Gravity(GameObject _gameObject, bool onGround, Rigidbody rb, Vector3 groundNormal) {
        Vector3 gravDirection = (_gameObject.transform.position - planet.transform.position).normalized;

        if (onGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }
        Quaternion toRotation = Quaternion.FromToRotation(_gameObject.transform.up, groundNormal) * _gameObject.transform.rotation;
        _gameObject.transform.rotation = toRotation;
    }
}
