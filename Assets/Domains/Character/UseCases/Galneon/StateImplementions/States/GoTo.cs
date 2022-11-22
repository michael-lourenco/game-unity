using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoTo : IState
{

    private GameObject ownerGameObject;

    public Vector3 localizationToGo;
    public Vector3 initialLocalization;
    public NavMeshAgent navMeshAgent;

    public bool goToCompleted;

    private System.Action<GoToResults> goToResultsCallback;

    public GoTo(
        GameObject ownerGameObject,
        Vector3 localizationToGo,
        Vector3 initialLocalization,
        NavMeshAgent navMeshAgent,
        Action<GoToResults> goToResultsCallback)
    {
        this.ownerGameObject = ownerGameObject;
        this.localizationToGo = localizationToGo;
        this.initialLocalization = initialLocalization;
        this.navMeshAgent = navMeshAgent;
        this.goToResultsCallback = goToResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter GoTo");
    }

    public void Execute()
    {
        if (!goToCompleted)
        {

            Debug.Log("LOCAL TO GO" + localizationToGo.ToString());
            this.navMeshAgent.SetDestination(localizationToGo);

            var goToResults = new GoToResults(localizationToGo, this.initialLocalization);

            // this is where should send the information back.
            this.goToResultsCallback(goToResults);

            goToCompleted = true;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit GoTo");
        goToCompleted = false;
    }
}

public class GoToResults
{
    public Vector3 localizationToGo;
    public Vector3 initialLocalization;
    // closest object
    // farthest object

    public GoToResults(Vector3 localizationToGo, Vector3 initialLocalization)
    {
        this.localizationToGo = localizationToGo;
        this.initialLocalization = initialLocalization;
                    
        // method calls to further process this data
    }
}
