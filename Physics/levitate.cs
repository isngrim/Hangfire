using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitate : MonoBehaviour
{
    public bool driver;
    Rigidbody rigidbody;
    public float force;
    public float rotspeed;
    // Start is called before the first frame update
    void Start()
    {
     
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, 10f))
        {
            rigidbody.AddForce(-Physics.gravity);
        }
        if(driver == true)
        {
            if (Input.GetKeyDown(KeyCode.W)){
                rigidbody.AddForce(transform.forward * force);
                
            }
            rigidbody.AddTorque(transform.up *rotspeed * Input.GetAxis("Horizontal")* Time.deltaTime,ForceMode.VelocityChange);

        }
    }
}
