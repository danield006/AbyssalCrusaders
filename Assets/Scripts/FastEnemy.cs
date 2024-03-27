using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FastEnemy : MonoBehaviour, IDamageable
{
    public List<GameObject> drops;
    NavMeshAgent enemy;
    GameObject player;
    public Transform orientation;
    public float speed;
    public event Action OnDeath;
    public event Action<int> OnTakeDamage;
    private float timer = 10f;
    
    //stats
    public int health;
    public int attack;

    //flash
    MeshRenderer meshRenderer;
    Color origColor;
    float flashTime = .15f;

    int lastMinute = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform);
        //flash
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        origColor = meshRenderer.material.color;
        
    }

    // Update is called once per frame
    private void Update() 
    {
        enemy.Move(orientation.forward * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (timer <= 0) {
            transform.LookAt(player.transform);
            timer = 10f;
        }

        if(StaticData.surviveMin > lastMinute) {
            lastMinute = StaticData.surviveMin;
            health ++;
            attack++;
        }
    }

    private void spawnDrop() {
        Vector3 location = transform.position;
        location = new Vector3(location.x, 1, location.z);
        float dropChance = UnityEngine.Random.Range(0f, 100f);
        GameObject drop = drops[0]; //drop small exp 35% 0 - 35
        if(dropChance < 35) {
            drop = drops[0]; //drop small exp 35% 0 - 35
        } else if(dropChance > 35 && dropChance < 60) {
            drop = drops[1]; //drop medium exp 25% 35 - 60
        } else if(dropChance > 60 && dropChance < 75) {
            drop = drops[2]; //drop big exp 15% 60 - 75
        } else if(dropChance > 75 && dropChance < 85) {
            drop = drops[3]; //drop giant exp 10% 75 - 85
        } else if(dropChance > 85) {
            drop = drops[4]; //drop health and random exp 15% 85 - 100
            Instantiate(drop, location, Quaternion.identity);

            int random2 = UnityEngine.Random.Range(0, 4);
            switch(random2) {
                case 0:
                    drop = drops[0]; //drop small exp 25%
                    break;
                case 1:
                    drop = drops[1]; //drop medium exp 25%
                    break;
                case 2:
                    drop = drops[2]; //drop big exp 25%
                    break;
                case 3:
                    drop = drops[3]; //drop giant exp 25%
                    break;
            }
        }
        
        Instantiate(drop, location, Quaternion.identity);
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        StartCoroutine(EFlash());
        if (health <= 0)
        {
            spawnDrop();
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        throw new NotImplementedException();
    }
    public int Health {
        get {
        return health;
    } set{
        health = value;    
    } }

    private void OnCollisionEnter(Collision other) {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null && other.gameObject.tag == "Player")
        {
            damageable.Damage(attack);
        }
        
    }

    IEnumerator EFlash() {
        meshRenderer.material.color = Color.white;
        yield return new WaitForSeconds(flashTime);
        meshRenderer.material.color = origColor;
    }
}