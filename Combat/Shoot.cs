using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    float damage;
    [SerializeField]
    float fireRate;
    [SerializeField]
    float range;
    [SerializeField]
    Transform barrelEnd;
    Input_Handler input;
    void Start()
    {
      
        input = GetComponentInParent<Input_Handler>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Firing", input.fire);
        if (input.fire == 1)
        {
            
            Ray ray = new Ray(barrelEnd.position, barrelEnd.forward);
            RaycastHit hit;
            Debug.DrawRay(barrelEnd.position, barrelEnd.forward * range, Color.red,.8f);
            if(Physics.Raycast(ray,out hit, range))
            {
                Rigidbody hitRB = hit.collider.GetComponent<Rigidbody>();
                Damageable hitDamageable = hit.collider.GetComponent<Damageable>();
                Debug.Log(hit.collider);
                if (hitRB != null)
                {
                    Vector3 dir = hit.point - this.transform.position;
                    hitRB.AddForceAtPosition(dir * 100, hit.point);
                }
                if (hitDamageable != null)
                {
                    hitDamageable.DecrementHealth(damage);
                }
        

            }
        }
    }
}
