using Assets.Script.NPCCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace AI_FSM 
{
    public class FiniteStateMachine : MonoBehaviour
    {
        [SerializeField]
        AbstractFSMState startingState;
        [SerializeField]
        AbstractFSMState currentState;
        [SerializeField]
      public  ExecutionState executionState;
        [SerializeField]
        List<AbstractFSMState> _validStates;
        Dictionary<FSMStateType, AbstractFSMState> _fsmStates;
        NavMeshAgent navMeshAgent;
        NPC npc;
        Ai_Input ai_Input;
     
        public void Awake()
        {
            currentState = null;
            ai_Input = GetComponent<Ai_Input>();
            _fsmStates = new Dictionary<FSMStateType, AbstractFSMState>();
             navMeshAgent = this.GetComponent<NavMeshAgent>();
             npc = this.GetComponent<NPC>();
            navMeshAgent.updatePosition = false;
            navMeshAgent.updateRotation = false;
           
            foreach (AbstractFSMState state in _validStates)
            {
                _fsmStates.Add(state.StateType, state);
            }
        }
        public void Start()
        {
            if(startingState != null)
            {
       
                EnterState(startingState);
            }
        }
        public void Update()
        {
            if(currentState != null)
            {
                currentState.InitializeState(this, npc, navMeshAgent,ai_Input);
                currentState.UpdateState();
                if(executionState == ExecutionState.TERMINATED)
                {
                    EnterState(FSMStateType.IDLE);

                }
            }
        }

        #region STATE MANAGEMENT

        public void EnterState(AbstractFSMState nextState)
        {
            if(nextState == null)
            {
                return;
            }
            if(currentState != null)
            {
                currentState.ExitState();
            }
            
            currentState = nextState;
           currentState.InitializeState(this, npc, navMeshAgent, ai_Input);
            currentState.EnterState();
        }
        public void EnterState(FSMStateType stateType)
        {
            if (_fsmStates.ContainsKey(stateType))
            {
                AbstractFSMState nextState = _fsmStates[stateType];
            
                EnterState(nextState);
            }
        }
        #endregion
    }
}



