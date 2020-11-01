

using Assets.Script.NPCCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI_FSM
{
    public enum ExecutionState
    {
        NONE,
        ACTIVE,
        COMPLETED,
        TERMINATED,
    }
    public enum FSMStateType
    {
        IDLE,
        PATROL,
        COMBAT
    }
    public abstract class AbstractFSMState : ScriptableObject
    {
        protected NavMeshAgent _navMeshAgent;
        protected NPC _npc;
        protected FiniteStateMachine _fsm;
        public ExecutionState ExecutionState { get; protected set; }
        public FSMStateType StateType { get; protected set; }
        public bool EnteredState { get; protected set; }
        protected Ai_Input ai_Input;

        public virtual void OnEnable()
        {
            ExecutionState = ExecutionState.NONE;
        }
        public virtual bool EnterState()
        {
            bool successNavMesh = true;
            bool successNPC = true;
            ExecutionState = ExecutionState.ACTIVE;
            //does the navmeshagent exist?
            successNavMesh = (_navMeshAgent != null);
            //does Executing agent exist
            successNPC = (_npc != null);
            return successNavMesh & successNPC;
        }
        public abstract void UpdateState();

        public virtual bool ExitState()
        {
            ExecutionState = ExecutionState.COMPLETED;
            return true;
        }
        public void InitializeState(FiniteStateMachine fsm, NPC npc, NavMeshAgent navMeshAgent,Ai_Input ai_Input)
        {
          SetExecutingFSM(fsm);
          SetExecutingNPC(npc);
            SetNavMeshAgent(navMeshAgent);
            SetAI_Input(ai_Input);

        }
        public virtual void SetAI_Input(Ai_Input _ai_Input)
        {
            if (_ai_Input != null)
            {
                ai_Input = _ai_Input;
            }
        }
        public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
        {
            if (navMeshAgent != null)
            {
                _navMeshAgent = navMeshAgent;
            }
        }
        public virtual void SetExecutingFSM(FiniteStateMachine fsm)
        {
            if (fsm != null)
            {
                _fsm = fsm;
            }
        }
        public virtual void SetExecutingNPC(NPC npc)
        {
            if (npc != null)
            {
                _npc = npc;
            }
        }
    }
}

