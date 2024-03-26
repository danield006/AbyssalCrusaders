using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    private Camera cam;
    private float target;
    [SerializeField] private float reduceSpeed = 2;
    [SerializeField] private Image dashBarSprite;

    void Start() {
        cam = Camera.main;
    }
   
    public void UpdateDashBar(float dashCooldown, float timeLeft) {
        dashBarSprite.fillAmount = timeLeft / dashCooldown;
    }

    void Update() {
        Quaternion newRotation = cam.transform.rotation;
        newRotation.Set(0.9f, newRotation.y, newRotation.z, newRotation.w);
        transform.rotation = newRotation;
        //reloadBarSprite.fillAmount = Mathf.MoveTowards(reloadBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}