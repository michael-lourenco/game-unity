using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ktpStateController : MonoBehaviour
{
    public ktpEnemyStats enemyStats;
    public ktpState currentState;
    public ktpState remainState;

    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public SkillMonoBehaviour skill;
    [HideInInspector] public List<Transform> wayPoints;
    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public Transform target;
    [HideInInspector] public Vector3 lastKnownTargetPosition;
    [HideInInspector] public bool stateBoolVariable;
    [HideInInspector] public float stateTimeElapsed;

    public Transform player;
    public bool alreadyAttacked;
    public GameObject projectile;

    public LayerMask whatIsGround, whatIsPlayer;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private bool _isActive;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        skill = GetComponent<SkillMonoBehaviour>();
        player = GameObject.Find("Caitlyn").transform;
    }

    private void Update()
    {
        if (!_isActive) return;
        currentState.UpdateState(this);
    }
    public void InitializeAI(bool activate, List<Transform> waiPointList)
    {
        wayPoints = waiPointList;
        _isActive = activate;
        agent.enabled = _isActive;
    }

    public void TransitionToState(ktpState nexState)
    {
        if (nexState != remainState)
        {
            currentState = nexState;
            OnExitState();
        }
    }
    
    public bool HasTimeElapsed(float duration) {
        stateTimeElapsed +=Time.deltaTime;
        if(stateTimeElapsed >= duration) {
            stateTimeElapsed = 0;
            return true;
        }
        else 
            return false;
    }

    private void OnExitState(){
        stateBoolVariable = false;
        stateTimeElapsed = 0;
    }
    private void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.gizmoColor;
            Gizmos.DrawWireSphere(transform.position, 1.5f);
        }
    }
}
