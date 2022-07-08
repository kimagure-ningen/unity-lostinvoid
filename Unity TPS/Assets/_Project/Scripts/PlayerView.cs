using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public Text _health;
    public Text _oxygen;
    public Text _hunger;

    private float startHealth = 100f;
    private float health;
    private float oxygen;
    private float hunger;

    private void Start()
    {
        health = startHealth;
    }

    

}
