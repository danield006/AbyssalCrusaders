using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public List<GameObject> menuPanels;
    public Damage playerStat;
    public PlayerController playerSpeed;
    public bullet playerReload;
    public HealthBar healthBar;

    public void healthUp() {
        playerStat.maxHealth++;
        playerStat.currentHealth++; 
        healthBar.UpdateHealthBar(playerStat.maxHealth, playerStat.currentHealth);
        foreach(GameObject menuPanel in menuPanels) {
            menuPanel.SetActive(false);
        }
        
        Time.timeScale = 1f;
    }

    public void attackUp() {
        playerStat.attack++; 
        
        foreach(GameObject menuPanel in menuPanels) {
            menuPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void speedUp() {
        playerSpeed.speed *= 1.05f;

        foreach(GameObject menuPanel in menuPanels) {
            menuPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void cooldownUp() {
        playerSpeed.dashCooldown *= 0.8f;

        foreach(GameObject menuPanel in menuPanels) {
            menuPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    public void reloadUp() {
        playerReload.reloadTimer *= 0.85f;

        foreach(GameObject menuPanel in menuPanels) {
            menuPanel.SetActive(false);
        }
        Time.timeScale = 1f;
    }
}
