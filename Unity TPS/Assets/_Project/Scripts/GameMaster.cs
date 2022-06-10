using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> spawnedEnemy;

    void Start() {
        spawnedEnemy = new List<GameObject>();
    }

    void Update() {
        if (spawnedEnemy.Count < 1) {
            spawnedEnemy.Add(Instantiate(enemy, new Vector3(0,0,22), Quaternion.identity));
        }
    }
}
