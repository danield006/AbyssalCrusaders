using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    private Camera cam;
    private float target;
    [SerializeField] private float reduceSpeed = 2;
    [SerializeField] private Image reloadBarSprite;

    void Start() {
        cam = Camera.main;
    }
   
    public void UpdateReloadBar(float reloadTime, float timeLeft) {
        reloadBarSprite.fillAmount = timeLeft / reloadTime;
    }

    void Update() {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        //reloadBarSprite.fillAmount = Mathf.MoveTowards(reloadBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}