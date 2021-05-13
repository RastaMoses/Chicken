using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : ScriptableObject
{
    public void Tick(int burnDamage, PlayerHealth health)
    {
        health.TakeDamage(burnDamage);
    }

    public string GetName()
    {
        return this.name;
    }
}
