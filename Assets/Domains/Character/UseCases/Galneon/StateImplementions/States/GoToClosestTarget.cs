using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToClosestTarget : IState
{

    private GameObject ownerGameObject;

    private GameObject enemyGameObject;

    public Vector3 initialLocalization;
    public NavMeshAgent navMeshAgent;

    public bool goToCompleted;

    private System.Action<GoToClosestTargetResults> goToResultsCallback;

    public GoToClosestTarget(
        GameObject ownerGameObject,
        GameObject enemyGameObject,
        Vector3 initialLocalization,
        NavMeshAgent navMeshAgent,
        Action<GoToClosestTargetResults> goToResultsCallback)
    {
        this.ownerGameObject = ownerGameObject;
        this.enemyGameObject = enemyGameObject;
        this.initialLocalization = initialLocalization;
        this.navMeshAgent = navMeshAgent;
        this.goToResultsCallback = goToResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter GoToClosestTarget");
    }

    public void Execute()
    {
        if (!goToCompleted)
        {

            Debug.Log("LOCAL TO GO" + enemyGameObject.transform.position.ToString());
            this.navMeshAgent.SetDestination(enemyGameObject.transform.position);

            var goToResults = new GoToClosestTargetResults(enemyGameObject, this.initialLocalization);

            // this is where should send the information back.
            this.goToResultsCallback(goToResults);

            goToCompleted = true;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GoToClosestTarget");
        goToCompleted = false;
    }
}

public class GoToClosestTargetResults
{
    public GameObject enemyGameObject;
    public Vector3 initialLocalization;
    // closest object
    // farthest object

    public GoToClosestTargetResults(GameObject enemyGameObject, Vector3 initialLocalization)
    {
        this.enemyGameObject = enemyGameObject;
        this.initialLocalization = initialLocalization;
                    
        // method calls to further process this data
    }
}
