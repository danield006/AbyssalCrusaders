using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangeEnemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float timer = 5f;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;

    public List<GameObject> drops;
    NavMeshAgent enemy;
    GameObject player;

    public event Action OnDeath;
    public event Action<int> OnTakeDamage;

    
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
        ShootAtPlayer();

        if(enemy.remainingDistance <= enemy.stoppingDistance) {
            enemy.updateRotation = false;

            transform.LookAt(player.transform);
        }
        else {
            enemy.updateRotation = true;
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

    void ShootAtPlayer() {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 3f);
    }
}

