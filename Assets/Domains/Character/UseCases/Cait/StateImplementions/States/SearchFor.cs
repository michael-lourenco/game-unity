using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchFor : IState
{
    private LayerMask searchLayer;

    private GameObject ownerGameObject;

    private float searchRadius;

    private string tagToLookFor;

    public bool searchCompleted;

    private System.Action<SearchResults> searchResultsCallback;

    public SearchFor(
        LayerMask searchLayer,
        GameObject ownerGameObject,
        float searchRadius,
        string tagToLookFor,
        Action<SearchResults> searchResultsCallback)
    {
        this.searchLayer = searchLayer;
        this.ownerGameObject = ownerGameObject;
        this.searchRadius = searchRadius;
        this.tagToLookFor = tagToLookFor;
        this.searchResultsCallback = searchResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter SearchFor");
    }

    public void Execute()
    {
        if (!searchCompleted)
        {

            var hitObjects = Physics.OverlapSphere(this.ownerGameObject.transform.position, this.searchRadius);

            var allObjectsWithTheRequiredTag = new List<Collider>();

            for (int i = 0; i < hitObjects.Length; i++)
            {
                if (hitObjects[i].CompareTag(this.tagToLookFor))
                {
                    allObjectsWithTheRequiredTag.Add(hitObjects[i]);
                }
            }

            var searchResults = new SearchResults(hitObjects, allObjectsWithTheRequiredTag);

            // this is where should send the information back.
            this.searchResultsCallback(searchResults);

            searchCompleted = true;
        } else {
            Exit();
        }
    }

    public void Exit()
    {
        Debug.Log("Exit SearchFor");
    }
}

public class SearchResults
{
    public Collider[] allHitObjectsInSearchRadius;
    public List<Collider> allHitObjectsWithRequiredTag;

    // closest object
    // farthest object

    public SearchResults(Collider[] allHitObjectsInSearchRadius, List<Collider> allHitObjectsWithRequiredTag)
    {
        this.allHitObjectsInSearchRadius = allHitObjectsInSearchRadius;
        this.allHitObjectsWithRequiredTag = allHitObjectsWithRequiredTag;

        // method calls to further process this data
    }
}
