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

    
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        transform.LookAt(player.transform);
        
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
        enemy.Move(orientation.forward * (speed/100));
    }

    private void spawnDrop() {
        Vector3 location = transform.position;
        GameObject drop = drops[0];//add a way for random drops
        Instantiate(drop, location, Quaternion.identity);
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

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
            damageable.Damage(1);
        }
        
    }
}