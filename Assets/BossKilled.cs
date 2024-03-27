using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossKilled : MonoBehaviour
{   
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss2;

    [SerializeField] bool isBoss3;
    void Update()
    {
        if(!isBoss3) {
            if(gameObject.GetComponent<Enemy>().health <=0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } 
        }
        else if(isBoss3) {
            if(boss1 == null && boss2 == null) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
