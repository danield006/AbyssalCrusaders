using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask groundMask;
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float fireForce = 20f;

    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1Cooldown = 3;

    private bool isAbility1Cooldown = false;
    private float currentAbility1Cooldown;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityText1.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Ability1Input();

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityImage1, abilityText1);
    }

    private void Ability1Input(){
        if(Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
            Shoot();
        }
    }

    private void Shoot(){
        if (Input.GetKeyDown(ability1Key)){
            var projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireForce;
        }
    }

    private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                var direction = position - transform.position;

                // You might want to delete this line.
                // Ignore the height difference.
                direction.y = 0;

                // Make the transform look in the direction.
                transform.forward = direction;
            }
        }

    private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }


    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText){
        if(isCooldown){
            currentCooldown -= Time.deltaTime;

            if(currentCooldown <= 0f){
                isCooldown = false;
                currentCooldown = 0f;

                if(skillImage != null){
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null){
                    skillText.text = "";
                }
            }

            else{
                if(skillImage != null){
                    skillImage.fillAmount = currentCooldown/maxCooldown;
                }
                if(skillText != null){
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
