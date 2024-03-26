using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject hoverImage;


    public void OnPointerEnter(PointerEventData eventData) {
        hoverImage.SetActive(true);
    }
    
    public void OnPointerExit(PointerEventData eventData) {
        hoverImage.SetActive(false);
    }
}
