using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damage : MonoBehaviour, IDamageable
{
    public TextMeshProUGUI healthText;
    public int currentHealth;
    public int maxHealth = 10;
    public event Action OnDeath;
    public event Action<int> OnTakeDamage;

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth) currentHealth = maxHealth;

        healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }

    void IDamageable.Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }

    private void Start() {
        currentHealth = maxHealth;
        healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }

    public int Health {
        get {
        return currentHealth;
    } set{
        currentHealth = value;

        healthText.text = "Health: " + currentHealth + "/" + maxHealth;    
    } }

}
