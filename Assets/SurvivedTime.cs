using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurvivedTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    
    void Start()
    {
        int minutes = StaticData.surviveMin;
        int seconds =  StaticData.surviveSec;
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
