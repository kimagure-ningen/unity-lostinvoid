using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject gameMaster;
    private GameMaster masterScript;

    //* Health
    private float maxHealth = 100f;
    public float currentHealth;

    public GameObject damageIndicator;

    private void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        if (gameMaster == null)
        {
            Debug.LogError("GameMaster not found.");
        }
        masterScript = gameMaster.GetComponent<GameMaster>();

        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            OnEnemyDeath();
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;

        DamageIndicator indicator = Instantiate(damageIndicator, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageIndicator(damage);
    }

    private void OnEnemyDeath()
    {
        masterScript.spawnedEnemy.RemoveAt(0);
        Destroy(gameObject);
    }
}
