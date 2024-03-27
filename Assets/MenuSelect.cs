using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StaticData.level = 1;
    }

    public void OpenSettings() {
        
    }

    public void ExitGame() {
        Application.Quit();
    }
}
