using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ActiveState : IState
{

    private SkillMonoBehaviour skillMonoBehaviour;
    private GameObject skillPrefab;
    private Transform transformLocationToInstantiate;
    private float activeTime;
    private Image skillImage;
    private float cooldownTime;
    private System.Action<ActiveStateResults> activeStateResultsCallback;

    public ActiveState(
        SkillMonoBehaviour skillMonoBehaviour,
        GameObject skillPrefab,
        Transform transformLocationToInstantiate,
        float activeTime,
        Image skillImage,
        float cooldownTime,
        System.Action<ActiveStateResults> activeStateResultsCallback
    )
    {

        this.skillMonoBehaviour = skillMonoBehaviour;
        this.skillPrefab = skillPrefab;
        this.transformLocationToInstantiate = transformLocationToInstantiate;
        this.activeTime = activeTime;
        this.skillImage = skillImage;
        this.cooldownTime = cooldownTime;
        this.activeStateResultsCallback = activeStateResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter ActiveState");
    }

    public void Execute()
    {
        if (this.activeTime >= 0f)
        {
            this.activeTime -= Time.deltaTime;
            this.skillImage.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        }
        else
        {
            this.skillMonoBehaviour.skill.BeginCooldown(skillPrefab.gameObject);

            this.cooldownTime = this.skillMonoBehaviour.skill.cooldownTime;
            this.skillImage.fillAmount = 0f;
            this.activeTime = 0f;

            var activeResults = new ActiveStateResults("teste");

            // this is where should send the information back.
            this.activeStateResultsCallback(activeResults);
        }
    }

    public void Exit()
    {
        Debug.Log("Exit ActiveState");
    }
}

public class ActiveStateResults
{
    public string test;

    public ActiveStateResults(string test)
    {
        this.test = test;
        // method calls to further process this data
    }
}