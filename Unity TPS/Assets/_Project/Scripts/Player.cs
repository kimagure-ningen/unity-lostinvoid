using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //* Hunger
    private float maxHunger = 100f;
    private float hungerDepletionRate = 1f;
    public float currentHunger;

    //* Oxygen
    private float maxOxygen = 100f;
    private float oxygenDepletionRate = 5f;
    public float currentOxygen;

    private void Start() {
        currentHunger = maxHunger;
        currentOxygen = maxOxygen;
    }

    private void Update() {
        currentHunger -= hungerDepletionRate * Time.deltaTime;
        currentOxygen -= oxygenDepletionRate * Time.deltaTime;

        if (currentHunger <= 0) {
            currentHunger = 0;
        }

        if (currentOxygen <= 0) {
            currentOxygen = 0;
        }
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
