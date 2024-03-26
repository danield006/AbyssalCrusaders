using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public GameObject LevelUpMenu;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public int exp;
    public int level;
    public int cap;

    [SerializeField] private ExpBar expBar;
    void Start()
    {
        exp = 0;
        level = 1;
        cap = Mathf.RoundToInt( 0.04f * Mathf.Pow(level, 3) + 0.8f * Mathf.Pow(level, 2) + 2 * level);

        expText.text = "Exp: " + exp.ToString() + "/" + cap.ToString();
        levelText.text = "Level " + level.ToString();
    }

    void Update()
    {
        if(exp >= cap) {
            levelUp();
        }
        expBar.UpdateExpBar(cap, exp);
    }
    private void levelUp() {
        level++;
        exp = exp - cap;

        cap = Mathf.RoundToInt( 0.04f * Mathf.Pow(level, 3) + 0.8f * Mathf.Pow(level, 2) + 2 * level);
        expText.text = "Exp: " + exp.ToString() + "/" + cap.ToString();
        levelText.text = "Level " + level.ToString();

        LevelUpMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    //deals with all pickup code
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Entered collision with " + other.gameObject.name);
        if(other.gameObject.tag == "Small Exp") {
            exp += 1;
            expText.text = "Exp: " + exp.ToString() + "/" + cap.ToString();
            Destroy(other.gameObject);
        } else if(other.gameObject.tag == "Medium Exp") {
            exp += 3;
            Destroy(other.gameObject);
        } else if(other.gameObject.tag == "Big Exp") {
            exp += 5;
            Destroy(other.gameObject);
        } else if(other.gameObject.tag == "Giant Exp") {
            exp += 10;
            Destroy(other.gameObject);
        } else if(other.gameObject.tag == "HealthPack") {
            int maxHp = gameObject.GetComponent<Damage>().maxHealth;
            int healAmount = maxHp / 10; // heals for 10% of max hp
            gameObject.GetComponent<Damage>().Heal(healAmount);
            Destroy(other.gameObject);
        }
    }
}
