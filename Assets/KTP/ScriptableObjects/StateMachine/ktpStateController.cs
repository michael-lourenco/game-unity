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

    public GameObject enemy;
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    public LayerMask whatIsGround, whatIsEnemy;

    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;

    public string tagToFind;
    private bool _isActive;

    public float maxHp;
    public float currentHp;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        skill = GetComponent<SkillMonoBehaviour>();
        enemy = GameObject.FindGameObjectWithTag(tagToFind);//GameObject.Find("Caitlyn");
        this.maxHp = enemyStats.hp;
        this.currentHp = enemyStats.hp;


    }

    private void Update()
    {
        if (!_isActive) return;
        currentState.UpdateState(this);
    }
    public void InitializeAI(bool activate, List<Transform> waiPointList)
    {
        if(!_isActive) {
            wayPoints = waiPointList;
            _isActive = activate;
            agent.enabled = _isActive;
        }
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

    public void TakeDamage(float amount) {
        this.currentHp -= amount;
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

        private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {
            Debug.Log("COLIDIU");
            this.TakeDamage(other.gameObject.GetComponent<BasicAttack3DMonoBehaviour>().DoDamage());
            

            Destroy(other.gameObject);
            if(this.currentHp <= 0f){
                this.gameObject.SetActive(false);
            }
        }
    }
}
