using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{

    //stats
    public int health = 2;
    public int attack = 1;
    

    public List<GameObject> drops;
    NavMeshAgent enemy;
    GameObject player;

    public event Action OnDeath;
    public event Action<int> OnTakeDamage;

    //flash
    [SerializeField] Renderer materialRenderer;
    float flashTime = .15f;
    Material mat;
    Color baseColor = Color.white * Mathf.LinearToGammaSpace (1.0f);
    Color finalColor;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");

        //flash
        finalColor = baseColor * Mathf.LinearToGammaSpace (0.0f);
        mat = materialRenderer.material;

    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
        
        //Material mat = GetComponent<Renderer>().material;
        //float emission = Mathf.PingPong (Time.time, 1.0f); //goes from 0 to 1
		//Color baseColor = Color.yellow; //Replace this with whatever you want for your base color at emission level '1'

		//Color finalColor = baseColor * Mathf.LinearToGammaSpace (1.0f);


    }

    private void spawnDrop() {
        Vector3 location = transform.position;
        location = new Vector3(location.x, 0.5f, location.z);
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
		mat.SetColor ("_EmissionColor", baseColor);
        mat.EnableKeyword("_EMISSION");//This is a bug in unity
        yield return new WaitForSeconds(flashTime);
        mat.SetColor ("_EmissionColor", finalColor);
        mat.EnableKeyword("_EMISSION");//This is a bug in unity
        
    }
}
