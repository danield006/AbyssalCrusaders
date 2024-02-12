using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger");
        Destroy(gameObject);
    }

}
