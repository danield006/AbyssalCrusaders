using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour, IDamageable
{
    public int currentHealth;
    public int maxHealth = 10;
    public int attack;
    public event Action OnDeath;
    public event Action<int> OnTakeDamage;

    [SerializeField] private HealthBar healthBar;

    private void Start() {
        //load stats
        maxHealth = StaticData.playerMaxHealth;
        attack = StaticData.playerAttack;

        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
    private void Update() {
        //update static data
        StaticData.playerMaxHealth = maxHealth;
        StaticData.playerAttack = attack;

    }
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth) currentHealth = maxHealth;

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    void IDamageable.Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
        if(currentHealth <= 0) {
            SceneManager.LoadScene("Loss Screen");
        }
    }



    public int Health {
        get {
        return currentHealth;
    } set{
        currentHealth = value;

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    } }

}
