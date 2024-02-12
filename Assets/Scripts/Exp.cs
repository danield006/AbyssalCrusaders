using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public int exp;
    public int level;
    public int cap;
    public GameObject PausePanel;
    void Start()
    {
        exp = 0;
        level = 1;
        cap = Mathf.RoundToInt( 0.04f * Mathf.Pow(level, 3) + 0.8f * Mathf.Pow(level, 2) + 2 * level);

        expText.text = "Exp: " + exp.ToString() + "/" + cap.ToString();
        levelText.text = "Level " + level.ToString();
    }

    public void Pause(){
        Debug.Log("Pause");
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    void Update()
    {
        if(exp >= cap) {
            levelUp();
            Pause();
        }
    }
    private void levelUp() {
        level++;
        exp = exp - cap;

        cap = Mathf.RoundToInt( 0.04f * Mathf.Pow(level, 3) + 0.8f * Mathf.Pow(level, 2) + 2 * level);
        expText.text = "Exp: " + exp.ToString() + "/" + cap.ToString();
        levelText.text = "Level " + level.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Entered collision with " + other.gameObject.name);
        if(other.gameObject.tag == "Dropped") {
            exp += 1;
            expText.text = "Exp: " + exp.ToString() + "/" + cap.ToString();
            Destroy(other.gameObject);
        }
    }
}
