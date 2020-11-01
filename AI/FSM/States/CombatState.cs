using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_FSM
{
    [CreateAssetMenu(fileName = "CombatState", menuName = "FSM/AI/States/Combat", order = 3)]
    public class CombatState : AbstractFSMState
    {
      

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.COMBAT;
        }
        public override bool EnterState()
        {
             base.EnterState();
            if(_npc.Target == null)
            {
                EnteredState = false;
                
            }
            if (EnteredState)
            {
               // Debug.Log("Entered Combat State");
            }
            return EnteredState;
        }
        public override void UpdateState()
        {
            if (EnteredState)
            {

                if (_npc.Target == null)
                {
                    _fsm.executionState = ExecutionState.COMPLETED;
                    ai_Input.ClearInput();
                    _fsm.EnterState(FSMStateType.IDLE);
                }
                else 
                {
                    _fsm.executionState = ExecutionState.ACTIVE;
                    ai_Input.LookAtTarget(_npc.Target);
                    ai_Input.AimAtTarget(_npc.Target);
                }
            }
            else
            {
                _fsm.executionState = ExecutionState.TERMINATED;
            }
        }
    }

}
