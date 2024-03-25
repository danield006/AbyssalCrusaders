using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public Damage playerStat;
    public PlayerController playerSpeed;
    public bullet playerReload;
    public HealthBar healthBar;

    public void healthUp() {
        playerStat.maxHealth++;
        playerStat.currentHealth++; 
        healthBar.UpdateHealthBar(playerStat.maxHealth, playerStat.currentHealth);
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void attackUp() {
        playerStat.attack++; 
        
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void speedUp() {
        playerSpeed.speed *= 1.05f;

        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void cooldownUp() {
        playerReload.reloadTimer *= 0.9f;
        playerSpeed.dashCooldown *= 0.8f;

        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
