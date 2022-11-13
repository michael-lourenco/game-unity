using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AICharacterMonoBehaviour : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    [SerializeField]
    private LayerMask enemiesLayer;
    [SerializeField]
    private float viewRange;
    [SerializeField]
    private float attackRange;

    [SerializeField]
    private string enemiesTag;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private GameObject enemyToGo;

    private void Start()
    {
        this.stateMachine.ChangeState(
            new SearchFor(
                enemiesLayer,
                this.gameObject,
                this.viewRange,
                this.enemiesTag,
                this.EnemyFound
                ));
    }

    private void Update()
    {
        this.stateMachine.ExecuteStateUpdate();
        /*if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            //lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                this.stateMachine.ChangeState(new GoToPlayer(this.gameObject, hit.point, this.navMeshAgent.transform.position, this.navMeshAgent, this.TriggerGoToPlayer));
            }
            //this.stateMachine.ChangeState(new GoToPlayer(this.gameObject, lastClickedPos, this.navMeshAgent, this.TriggerGoToPlayer));
        }*/
    }

    public void EnemyFound(SearchResults searchResults)
    {
        var foundEnemyItems = searchResults.allHitObjectsWithRequiredTag;
        Debug.Log("ENEMY FOUND " + foundEnemyItems.Count.ToString());
        this.stateMachine.ChangeState(new ChooseOne(this.gameObject, foundEnemyItems, this.TriggerChooseEnemy));
        // decide what to eat 
        // Trigger the eating cartridge
    }

    public void TriggerChooseEnemy(ChooseResults chooseResults)
    {
        Debug.Log("TRIGGER CHOOOSE ENEMY");
        var foodToGo = chooseResults.allHitObjectsWithRequiredTag;
        var randomNumber = Mathf.Round(Random.Range(0f, (float)foodToGo.Count));
        this.enemyToGo = foodToGo[(int)randomNumber].gameObject;
        Debug.Log("ENEMY TO GO " + foodToGo[(int)randomNumber]);
        this.stateMachine.ChangeState(new GoToPlayer(this.gameObject, this.enemyToGo, this.navMeshAgent.transform.position, this.navMeshAgent, this.TriggerGoToPlayer));
    }

    public void TriggerGoToPlayer(GoToPlayerResults goToResults)
    {
        var gotoLocalization = goToResults.initialLocalization;
        Debug.Log("TRIGGER GO TO");
        this.stateMachine.ChangeState(new GoToPlayer(this.gameObject, this.enemyToGo, this.navMeshAgent.transform.position, this.navMeshAgent, this.TriggerGoToPlayer));
    }

    public void TriggerBackTo(BackToResults backToResults)
    {
        Debug.Log("TRIGGER BACK TO");
    }


    public void TriggerAttack()
    {

    }
}
