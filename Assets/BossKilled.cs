using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossKilled : MonoBehaviour
{   
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss2;
    void Update()
    {
       if(boss1 == null && boss2 == null) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       StaticData.level++;
    }
}
