using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ReadyState : IState
{
    private SkillMonoBehaviour skillMonoBehaviour;
    private GameObject skillPrefab;
    private Transform transformLocationToInstantiate;
    private float activeTime;
    private Image skillImage;
    public KeyCode key;
    private System.Action<ReadyStateResults> readyStateResultsCallback;
    
    public ReadyState(
        SkillMonoBehaviour skillMonoBehaviour,
        GameObject skillPrefab,
        Transform transformLocationToInstantiate,
        float activeTime,
        Image skillImage,
        KeyCode key,
        System.Action<ReadyStateResults> readyStateResultsCallback
    )
    {

        this.skillMonoBehaviour = skillMonoBehaviour;
        this.skillPrefab = skillPrefab;
        this.transformLocationToInstantiate = transformLocationToInstantiate;
        this.activeTime = activeTime;
        this.skillImage = skillImage;
        this.key = key;
        this.readyStateResultsCallback = readyStateResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter ReadyState");
    }

    public void Execute()
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log("Execute ReadyState");
            this.skillMonoBehaviour.skill.Activate(this.skillPrefab.gameObject, this.transformLocationToInstantiate);
            this.activeTime = this.skillMonoBehaviour.skill.activeTime;
            this.skillImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            var readyResults = new ReadyStateResults("teste");

            // this is where should send the information back.
            this.readyStateResultsCallback(readyResults);

        }
    }

    public void Exit()
    {
        Debug.Log("Exit ReadyState");
    }
}

public class ReadyStateResults
{
    public string test;
    public ReadyStateResults(string test)
    {
        this.test = test;
        // method calls to further process this data
    }
}