using AI_FSM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
namespace Assets.Script.NPCCode
{[RequireComponent(typeof(NavMeshAgent),typeof(FiniteStateMachine))]
    public class NPC : MonoBehaviour
    {
        [SerializeField]
       public ConnectedWaypoint[] connectedWaypoints;
        public int connectedWaypointIndex;
        NavMeshAgent navMeshAgent;
        FiniteStateMachine finiteStateMachine;
        public GameObject Target;
       public float _idleDuration = 3f;
        public float _totalDuration;
        public void Awake()
        {
            connectedWaypointIndex = -1;
            navMeshAgent = this.GetComponent<NavMeshAgent>();
            finiteStateMachine = this.GetComponent<FiniteStateMachine>();
        }


        public ConnectedWaypoint[] ConnectedWaypoints
        {
            get
            {
                return connectedWaypoints;
            }
        }
    }
}


