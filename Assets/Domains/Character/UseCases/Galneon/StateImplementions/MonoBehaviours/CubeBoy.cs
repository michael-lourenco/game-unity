using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CubeBoy : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    [SerializeField]
    private LayerMask foodItemsLayer;
    [SerializeField]
    private float viewRange;
    [SerializeField]
    private float attackRange;

    [SerializeField]
    private string foodItemsTag;
    [SerializeField]
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
      /*  this.stateMachine.ChangeState(
            new SearchFor(
                foodItemsLayer,
                this.gameObject,
                this.viewRange,
                this.foodItemsTag,
                this.FoodFound
                ));*/
    }

    private void Update()
    {
        this.stateMachine.ExecuteStateUpdate();
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            //lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                this.stateMachine.ChangeState(new GoTo(this.gameObject, hit.point, this.navMeshAgent.transform.position, this.navMeshAgent, this.TriggerGoTo));
            }
            //this.stateMachine.ChangeState(new GoTo(this.gameObject, lastClickedPos, this.navMeshAgent, this.TriggerGoTo));
        }
    }

    public void FoodFound(SearchResults searchResults)
    {
        var foundFoodItems = searchResults.allHitObjectsWithRequiredTag;
        Debug.Log("FOOD FOUND " + foundFoodItems.Count.ToString());
        this.stateMachine.ChangeState(new ChooseOne(this.gameObject, foundFoodItems, this.TriggerChooseFood));
        // decide what to eat 
        // Trigger the eating cartridge
    }

    public void TriggerChooseFood(ChooseResults chooseResults)
    {
        Debug.Log("TRIGGER CHOOOSE FOOD");
        var foodToGo = chooseResults.allHitObjectsWithRequiredTag;
        var randomNumber = Mathf.Round(Random.Range(0f, (float)foodToGo.Count));
        Debug.Log("FOOD TO GO " + foodToGo[(int)randomNumber]);
        this.stateMachine.ChangeState(new GoTo(this.gameObject, foodToGo[(int)randomNumber].transform.position, this.navMeshAgent.transform.position, this.navMeshAgent, this.TriggerGoTo));
    }

    public void TriggerGoTo(GoToResults goToResults)
    {
        var gotoLocalization = goToResults.initialLocalization;
        Debug.Log("TRIGGER GO TO");
        //this.stateMachine.ChangeState(new BackTo(this.gameObject, gotoLocalization, this.navMeshAgent, this.TriggerBackTo));
    }

    public void TriggerBackTo(BackToResults backToResults)
    {
        Debug.Log("TRIGGER BACK TO");
    }


    public void TriggerEating()
    {

    }
}
