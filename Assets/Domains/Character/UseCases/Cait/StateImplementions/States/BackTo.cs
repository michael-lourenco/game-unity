using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BackTo : IState
{

    private GameObject ownerGameObject;

    public Vector3 localizationToBack;
    public NavMeshAgent navMeshAgent;

    public bool backToCompleted;

    private System.Action<BackToResults> backToResultsCallback;

    public BackTo(
        GameObject ownerGameObject,
        Vector3 localizationToBack,
        NavMeshAgent navMeshAgent,
        Action<BackToResults> backToResultsCallback)
    {
        this.ownerGameObject = ownerGameObject;
        this.localizationToBack = localizationToBack;
        this.navMeshAgent = navMeshAgent;
        this.backToResultsCallback = backToResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter BackTo");
    }

    public void Execute()
    {
        if (!backToCompleted)
        {

            Debug.Log("LOCAL TO BACK" + localizationToBack.ToString());
            this.navMeshAgent.SetDestination(localizationToBack);

            var backToResults = new BackToResults(localizationToBack);

            // this is where should send the information back.
            this.backToResultsCallback(backToResults);

            backToCompleted = true;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit BackTo");
        backToCompleted = false;
    }
}

public class BackToResults
{
    public Vector3 localizationToBack;
    // closest object
    // farthest object

    public BackToResults(Vector3 localizationToBack)
    {
        this.localizationToBack = localizationToBack;

        // method calls to further process this data
    }
}
