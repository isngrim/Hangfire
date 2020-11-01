using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{
    public GameObject attractionPoint;
    public LayerMask layer;
    Camera cam;
    Input_Handler input;

    Rigidbody rb;
    public float speed;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        input = GetComponentInChildren<Input_Handler>();
    }
    private void Update()
    {


    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100, layer))
            {
                //   Debug.Log
                LooseObject looseObject = hit.transform.GetComponent<LooseObject>();
                if (looseObject != null)
                {
                    Rigidbody testrb = looseObject.gameObject.GetComponent<Rigidbody>();
                    if (testrb != null)
                    {
                        Vector3 dir = attractionPoint.transform.position - hit.point;
                        testrb.AddForce(dir * (rb.mass * speed), ForceMode.VelocityChange);
                        testrb.velocity -= testrb.velocity;
                        rb.AddForceAtPosition(-dir * (testrb.mass * speed), hit.point, ForceMode.Acceleration);
                        rb.velocity -= rb.velocity;
                    }

                }
            }


        }
        if (Input.GetKey(KeyCode.Q))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100, layer))
            {
                //   Debug.Log
                LooseObject looseObject = hit.transform.GetComponent<LooseObject>();
                if (looseObject != null)
                {
                    Rigidbody testrb = looseObject.gameObject.GetComponent<Rigidbody>();
                    if (testrb != null)
                    {
                        Vector3 dir =   hit.point-attractionPoint.transform.position;
                        testrb.AddForceAtPosition(dir * (testrb.mass * speed), hit.point, ForceMode.VelocityChange);
                        testrb.velocity -= testrb.velocity;
                        rb.AddForce(-dir * (rb.mass * speed), ForceMode.Acceleration);
                       
                    }

                }
            }


        }
    }
}
