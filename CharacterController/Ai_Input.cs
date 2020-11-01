using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharacterPhysicsFsm;
using UnityEngine.AI;
using System;

public class Ai_Input : Abstract_Input_Handler
{

    [SerializeField]
    NavMeshAgent meshAgent;
    [SerializeField]
    Camera camera;
   public PhysicsStateType PhysicsStateType;

    void Start()
    {
      
        meshAgent = GetComponent<NavMeshAgent>();
        meshAgent.updatePosition = false;
        meshAgent.updateRotation = false;
    }

    public void SetMouseX(Vector3 lookTarget)
    {
        if (lookTarget != transform.position)
        {
          
            Vector3 dir = (lookTarget - this.transform.position).normalized;
            float dot = Vector3.Dot(transform.right, dir);

            if (transform.rotation.y != Quaternion.LookRotation(dir).y) { mouse_X = dot * Time.deltaTime; }

        }
    }
    public void SetMouseY(Vector3 lookTarget)
    {

        Vector3 dir = (lookTarget - camera.transform.position);
            float dot = Vector3.Dot(camera.transform.up, dir);
       
        if (camera.transform.rotation.x != Quaternion.LookRotation(dir).x)
        {
           mouse_y = Mathf.Lerp(mouse_y, Mathf.Clamp(mouse_y + dot * Time.deltaTime * 100, -viewRange, 90), .4f);
            

        }




    }
    public void SetVertical(Vector3 moveTarget)
    {
        Vector3 dir2 = (moveTarget - this.transform.position);
        float dot2 = Vector3.Dot(transform.forward, dir2.normalized);
        
            vertical =Mathf.Clamp( dot2,-1f,1f);
        
   
       
    }
    public void SetHorizontal(Vector3 moveTarget)
    {
        Vector3 dir = (moveTarget - this.transform.position).normalized;
        float dot = Vector3.Dot(transform.right, dir);
            horizontal = Mathf.Clamp(dot, -1f, 1f);

    }
    public void TryFire1(GameObject target)
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward,out hit, 100))
        {if (hit.transform.gameObject == target)
            {
                fire = 1;
                Debug.Log("pew");
            }
         
        }
        else
        {
            fire = 0;
        }
    }
    public void ClearInput()
    {
       
        mouse_X = 0;
        vertical = 0;
        horizontal = 0;
    }
    public void LookAtTarget(GameObject target)
    {
        SetMouseX(target.transform.position);

    }
    public void LookAtTarget(Vector3 target)
    {
        SetMouseX(target);
    }
    public void AimAtTarget(GameObject target)
    {
        SetMouseY(target.transform.position);
    }
    public void AimAtTarget(Vector3 target)
    {
        SetMouseY(target);
    }
    public void MoveToTarget(Vector3 target)
    {
        SetVertical(target);
        SetHorizontal(target);
    }
    public void MoveToTarget(GameObject target)
    {
        SetVertical(target.transform.position);
        SetHorizontal(target.transform.position);
    }

}
