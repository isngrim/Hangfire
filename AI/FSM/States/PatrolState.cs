using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI_FSM
{
    [CreateAssetMenu(fileName = "PatrolState", menuName = "FSM/AI/States/Patrol", order = 2)]
    public class PatrolState : AbstractFSMState
    {


       
        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.PATROL;
          
        }
        public override bool EnterState()
        {
            if (base.EnterState())
            {

                EnteredState = false;
  
                if (_npc.connectedWaypoints == null|| _npc.connectedWaypoints.Length == 0)
                {
                    Debug.LogError("PatrolState:Failed to grab Waypoints");
                
                }
                else
                {
                    if (_npc.connectedWaypointIndex < 0)
                    {
                        _npc.connectedWaypointIndex = UnityEngine.Random.Range(0, _npc.connectedWaypoints.Length);
                    }
                    else
                    {
                        _npc.connectedWaypointIndex = (_npc.connectedWaypointIndex + 1) % _npc.connectedWaypoints.Length;
                    }
                    _npc._totalDuration = 0;
                    ai_Input.PhysicsStateType = CharacterPhysicsFsm.PhysicsStateType.AI_FOLLOWPATH;
                    SetDestination(_npc.connectedWaypoints[_npc.connectedWaypointIndex]);
                }
                EnteredState = true;
            }
            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                _fsm.executionState = ExecutionState.ACTIVE;
                ai_Input.MoveToTarget(_navMeshAgent.nextPosition);
                ai_Input.LookAtTarget(_navMeshAgent.nextPosition);
                if (_npc.Target != null)
                {
                    ai_Input.ClearInput();
                    _fsm.EnterState(FSMStateType.COMBAT);
                }
                if (Vector3.Distance(_navMeshAgent.transform.position, _npc.connectedWaypoints[_npc.connectedWaypointIndex].transform.position) <= 1f)
                {
                    _npc._totalDuration += Time.deltaTime;
                    //_fsm.executionState = ExecutionState.COMPLETED;
                    ai_Input.ClearInput();
                    //_fsm.EnterState(FSMStateType.IDLE);
                    if (_npc._totalDuration >= _npc._idleDuration)
                    {
                        _npc.connectedWaypointIndex = (_npc.connectedWaypointIndex + 1) % _npc.connectedWaypoints.Length;
                        SetDestination(_npc.connectedWaypoints[_npc.connectedWaypointIndex]);
                        _npc._totalDuration = 0;

                    }
                }
                  
            }
            else 
            {
                _fsm.executionState = ExecutionState.TERMINATED;
            }
        }


        private void SetDestination(ConnectedWaypoint destination)
        {
            if(_navMeshAgent !=null && destination != null)
            {

                _navMeshAgent.SetDestination(destination.transform.position);
       

            }
        }
    }
}