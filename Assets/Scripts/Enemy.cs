using System;
using System.Collections;
using System.Collections.Generic;
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
		mat.SetColor ("_EmissionColor", baseColor);
        mat.EnableKeyword("_EMISSION");//This is a bug in unity
        yield return new WaitForSeconds(flashTime);
        mat.SetColor ("_EmissionColor", finalColor);
        mat.EnableKeyword("_EMISSION");//This is a bug in unity
        
    }
}
