using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    private float maxHealth = 100f;
    [HideInInspector]public float currentHealth;

    [Header("Hunger")]
    [HideInInspector] public float maxHunger = 100f;
    private float hungerDepletionRate = 0.5f;
    private float hungerDeficiencyDamage = 2f;
    [HideInInspector]public float currentHunger;

    [Header("Oxygen")]
    [HideInInspector]public float maxOxygen = 100f;
    private float oxygenDepletionRate = 1f;
    private float oxygenDeficiencyDamage = 10f;
    [HideInInspector]public float currentOxygen;

    [Header("Shooting Mode")]
    public CinemachineVirtualCamera vCam2;
    private int defaultPriority;
    public bool isShootingMode = false;
    public GameObject crosshair;

    private void Start() {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentOxygen = maxOxygen;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        crosshair.SetActive(false);

        defaultPriority = vCam2.Priority;
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

        if (Input.GetMouseButtonDown(1))
        {
            SwitchCamera();
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player Died");
        // Time.timeScale = 0;
    }

    public void SwitchCamera()
    {
        if (vCam2.Priority == 20)
        {
            vCam2.Priority = defaultPriority;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            crosshair.SetActive(false);
            isShootingMode = false;
        }
        else
        {
            vCam2.Priority = 20;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            crosshair.SetActive(true);
            isShootingMode = true;
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
