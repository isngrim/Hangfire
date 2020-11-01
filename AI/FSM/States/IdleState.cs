using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


  namespace AI_FSM
{
    [CreateAssetMenu(fileName = "IdleState", menuName = "FSM/AI/States/Idle", order = 1)]
    public class IdleState : AbstractFSMState
    {

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;
        }
        public override bool EnterState()
        {
            base.EnterState();
            if (EnteredState)
            {
                Debug.Log("Entered Idle State");
                _npc._totalDuration = 0;
            }
           
            EnteredState = true;

            return EnteredState;
            
        }
        public override void UpdateState()
        {
            if (EnteredState)
            {
               
             
               if(_npc.Target != null)
                {
                    _fsm.executionState = ExecutionState.COMPLETED;
                    _fsm.EnterState(FSMStateType.COMBAT);
                }
                _npc._totalDuration += Time.deltaTime;
                if (_npc._totalDuration >= _npc._idleDuration)
                {
                    _fsm.executionState = ExecutionState.COMPLETED;
                    _fsm.EnterState(FSMStateType.PATROL);
                }
                }
            
        }
        public override bool ExitState()
        {
            base.ExitState();
            Debug.Log("Exiting State");
            return true;
        }
    }
}

