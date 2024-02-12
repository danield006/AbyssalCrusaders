using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public List<GameObject> drops;
    NavMeshAgent enemy;
    GameObject player;
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
        kill();
    }

    public void kill() {
        if(Input.GetMouseButtonDown(0)) { //if left click on enemy
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) {
                if(hit.collider.gameObject) {
                    spawnDrop();
                    Destroy(gameObject);
                }
            }
        }
    }

    private void spawnDrop() {
        Vector3 location = transform.position;
        GameObject drop = drops[0];//add a way for random drops
        Instantiate(drop, location, Quaternion.identity);
    }
}
