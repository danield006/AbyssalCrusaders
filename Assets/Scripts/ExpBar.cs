using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private float target;
    [SerializeField] private float reduceSpeed = 2f;
    [SerializeField] private Image expBarSprite;

    void Start() {
        
    }
   
    public void UpdateExpBar(float maxExp, float currentExp) {
        target = currentExp / maxExp;

    }

    void Update() {
        expBarSprite.fillAmount = Mathf.MoveTowards(expBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
