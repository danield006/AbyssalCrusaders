using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public Damage playerHP;
    public PlayerController playerSpeed;
    public bullet playerReload;
    public TextMeshProUGUI healthText;

    public void healthUp() {
        playerHP.maxHealth++; 
        
        healthText.text = "Health: " + playerHP.currentHealth + "/" + playerHP.maxHealth;
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void speedUp() {
        playerSpeed.speed *= 1.05f;

        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void cooldownUp() {
        playerReload.reloadTimer -= 0.2f;
        playerSpeed.dashCooldown--;

        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
