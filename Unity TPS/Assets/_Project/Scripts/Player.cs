using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //* Health
    private float maxHealth = 100f;
    public float currentHealth;

    //* Hunger
    private float maxHunger = 100f;
    private float hungerDepletionRate = 1f;
    private float hungerDeficiencyDamage = 2f;
    public float currentHunger;

    //* Oxygen
    private float maxOxygen = 100f;
    private float oxygenDepletionRate = 5f;
    private float oxygenDeficiencyDamage = 10f;
    public float currentOxygen;

    private void Start() {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentOxygen = maxOxygen;
    }

    private void Update() {
        currentHunger -= hungerDepletionRate * Time.deltaTime;
        currentOxygen -= oxygenDepletionRate * Time.deltaTime;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnPlayerDeath();
        }

        if (currentHunger <= 0) {
            currentHunger = 0;
            Damage(hungerDeficiencyDamage * Time.deltaTime);
        }

        if (currentOxygen <= 0) {
            currentOxygen = 0;
            Damage(oxygenDeficiencyDamage * Time.deltaTime);
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player Died");
        Time.timeScale = 0;
    }

    public void ReplenishHunger(float hungerAmount) {
        currentHunger += hungerAmount;

        if (currentHunger > maxHunger){
            currentHunger = maxHunger;
        }
    }

    public void ReplenishOxygen(float oxygenAmount) {
        currentOxygen += oxygenAmount;

        if (currentOxygen > maxOxygen) {
            currentOxygen = maxOxygen;
        }
    }
}
