using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitPlayer : MonoBehaviour
{
    private int damageAmount;

    public void setDamage(int damage) {
        damageAmount = damage;
    }
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
