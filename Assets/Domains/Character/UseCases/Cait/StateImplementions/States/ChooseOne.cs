using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChooseOne : IState
{
    private GameObject ownerGameObject;

    private List<Collider> foundItems;

    public bool chooseCompleted;

    private System.Action<ChooseResults> chooseResultsCallback;

    public ChooseOne(
        GameObject ownerGameObject,
        List<Collider> foundItems,
        Action<ChooseResults> chooseResultsCallback)
    {
        this.ownerGameObject = ownerGameObject;
        this.foundItems = foundItems;
        this.chooseResultsCallback = chooseResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter ChooseOne");
    }

    public void Execute()
    {
        if (!chooseCompleted)
        {


            //var chooseResults = new ChooseResults(hitObjects, allObjectsWithTheRequiredTag);
            Debug.Log("O ESCOLHIDO FOI" + foundItems[0].ToString());

            var chooseResults = new ChooseResults(foundItems);

            // this is where should send the information back.
            this.chooseResultsCallback(chooseResults);
            chooseCompleted = true;
        }
    }

    public void Exit()
    {
        Debug.Log("Exit ChooseOne");
    }
}

public class ChooseResults
{
    public List<Collider> allHitObjectsWithRequiredTag;

    // closest object
    // farthest object

    public ChooseResults(List<Collider> allHitObjectsWithRequiredTag)
    {
        this.allHitObjectsWithRequiredTag = allHitObjectsWithRequiredTag;
        // method calls to further process this data
    }
}
