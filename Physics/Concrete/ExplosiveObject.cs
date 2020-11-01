using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObject : Damageable 
{

    Explosive explosive;

    private void OnEnable()
    {
        explosive = GetComponent<Explosive>();
    }

    public override void Die()
    {
        explosive.Explode();
        base.Die();
    }
}


