using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ktpStateController : MonoBehaviour
{
    
    public ktpCharAIStats ktpCharAIStats;
    public ktpState currentState;
    public ktpState remainState;

    [HideInInspector] public NavMeshAgent agent;
    //public SkillMonoBehaviour skill;
    [HideInInspector] public List<Transform> wayPoints;
    [HideInInspector] public int nextWaypoint;
    [HideInInspector] public Transform target;
    [HideInInspector] public Vector3 lastKnownTargetPosition;
    [HideInInspector] public bool stateBoolVariable;
    [HideInInspector] public float stateTimeElapsed;

    public GameObject enemy;
    //public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;

    public LayerMask whatIsGround, whatIsEnemy;

    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;

    public string tagToFind;
    private bool _isActive;
    [SerializeField] private Slider healthBar;

    [SerializeField] private Image healthFill;
    public float maxHp;
    public float currentHp;

    public Transform pointToInstantiateFire;
    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
        //skill = GetComponent<SkillMonoBehaviour>();
        enemy = GameObject.FindGameObjectWithTag(tagToFind);//GameObject.Find("Caitlyn");
        this.maxHp = ktpCharAIStats.hp;
        this.currentHp = ktpCharAIStats.hp;
        SetInitialHealth(ktpCharAIStats.hp);
    }

    public void SetInitialHealth(float maxHealth) {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public CurrentGameState GetCurrentGameState() {
        return GameController.instance.currentGameState;
    }

    public void SetCurrentGameState(CurrentGameState gameStateToChange) {
        GameController.instance.currentGameState = gameStateToChange;
    }

    public void UpdateHealth(float currentHealth){
        healthBar.value = currentHealth;
    }
    private void Update()
    {
        if (!_isActive) return;

        if(GameController.instance.currentGameState == CurrentGameState.ChooseMinions){
            return;
        }
        currentState.UpdateState(this);
    }
    public void InitializeAI(bool activate, List<Transform> waiPointList)
    {
        if (!_isActive)
        {
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

    public bool HasTimeElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        if (stateTimeElapsed >= duration)
        {
            stateTimeElapsed = 0;
            return true;
        }
        else
            return false;
    }

    private void OnExitState()
    {
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

    public void TakeDamage(float amount)
    {
        this.currentHp -= amount;
        UpdateHealth(this.currentHp);
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
            this.TakeDamage(other.gameObject.GetComponent<SkillMonoBehaviour>().DoDamage());


            Destroy(other.gameObject);
            if (this.currentHp <= 0f)
            {
                this.gameObject.SetActive(false);
                if(this.gameObject.tag == "Enemy"){
                    GameController.instance.quantityEnemies -=1;
                }
                
                Debug.Log("Inimigo"+GameController.instance.quantityEnemies.ToString());
            }
        }
    }
}
