using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Continue();
        }
    }

    public void Pause(){
        Debug.Log("Pause");
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue(){
        Debug.Log("Continue");
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
