using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LooseObject : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float mass = 1;
    // Start is called before the first frame update
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        LooseObject otherLoose = collision.collider.GetComponent<LooseObject>();
        Damageable otherColliderHealth = collision.collider.GetComponent<Damageable>();
        if( otherColliderHealth != null )
        {
            if(rb.velocity.magnitude > 6)
            {
                float damage = ((.5f * rb.mass) * rb.velocity.magnitude * 2f)/2;
                if(damage >= 2)
                {
                    otherColliderHealth.DecrementHealth(damage);
                }
               
            }
      
         
        }
    }
}
