using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour
{
    public int damageAmount = 1;
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision");
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
 
        if(damageable != null)
        {
             damageable.Damage(damageAmount);
             Destroy(gameObject);
        }
    }
}
