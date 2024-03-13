using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    int Health {get; set;}
    void Damage(int damageAmount);
    void Heal(int healAmount);
    event Action OnDeath;
    event Action<int> OnTakeDamage;
}
