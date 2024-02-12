using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    void Update()
    {
        spawnIn();
    }

     public void spawnIn() {
        if(Input.GetMouseButtonDown(2)) {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) {
                if(hit.collider.tag == "Ground") {
                    Vector3 location = new Vector3(hit.point.x, hit.point.y + 5, hit.point.z);
                    Instantiate(enemy, location, Quaternion.identity);
                }
            }
        }
     }
}
