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
    }

    private void spawnDrop() {
        Vector3 location = transform.position;
        GameObject drop = drops[0];//add a way for random drops
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