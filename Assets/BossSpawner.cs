using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemys;

    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    private float timeUntilSpawn;

    private float elapsedTime = 0f;
    public float spawnAtTime;
    bool spawned = false;
    // Start is called before the first frame update
    void Awake() {
        SetTimeUntilSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0 && elapsedTime > spawnAtTime && spawned == false) {
            foreach(GameObject enemy in enemys) {
                Vector3 spawnLocation = GetRandomPosOffScreen();
                Instantiate(enemy, spawnLocation, Quaternion.identity);
            }
            spawned = true;
            //SetTimeUntilSpawn(); spawns one only
        }
    }

    private void SetTimeUntilSpawn() {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }

    private Vector3 GetRandomPosOffScreen() {
 
        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(-0.2f, 0.2f);
        if (x >= 0) x += 1;
        if (y >= 0) y += 1;
        Vector3 randomPoint = new(x, y);
 
        randomPoint.z = 10f; // set this to whatever you want the distance of the point from the camera to be. Default for a 2D game would be 10.
        Vector3 worldPoint = Camera.main.ViewportToWorldPoint(randomPoint);
 
        return worldPoint;
    }
}
