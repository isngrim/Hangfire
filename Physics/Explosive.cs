using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Explosive : MonoBehaviour
{
    [SerializeField]
    float explosionForce = 300f;
    [SerializeField]
    float explosionRadius;
    [SerializeField]
    float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { Explode(); }
    }
    public virtual void Explode()
    {
      
       Collider[] colliders;
      colliders =  Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider col in colliders)
        {
          
            Rigidbody colrb = col.GetComponent<Rigidbody>();
            if(colrb != null)
            {
                colrb.AddExplosionForce(explosionForce, transform.position, explosionRadius,5f);
                Damageable colDamageable = colrb.GetComponent<Damageable>();
                if(colDamageable != null)
                {
                    colDamageable.DecrementHealth(damage);
                }
               
            }
                 }
    }

}
