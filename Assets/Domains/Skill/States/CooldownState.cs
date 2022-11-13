using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class CooldownState : IState
{
    private SkillMonoBehaviour skillMonoBehaviour;
    private GameObject skillPrefab;
    private Transform transformLocationToInstantiate;
    private float activeTime;
    private Image skillImage;
    private float cooldownTime;

    private TextMeshProUGUI skillCooldownText;

    private System.Action<CooldownStateResults> cooldownStateResultsCallback;

    public CooldownState(
        SkillMonoBehaviour skillMonoBehaviour,
        GameObject skillPrefab,
        Transform transformLocationToInstantiate,
        float activeTime,
        Image skillImage,
        float cooldownTime,
        TextMeshProUGUI skillCooldownText,
        System.Action<CooldownStateResults> cooldownStateResultsCallback
    )
    {

        this.skillMonoBehaviour = skillMonoBehaviour;
        this.skillPrefab = skillPrefab;
        this.transformLocationToInstantiate = transformLocationToInstantiate;
        this.activeTime = activeTime;
        this.skillImage = skillImage;
        this.cooldownTime = cooldownTime;
        this.skillCooldownText = skillCooldownText;
        this.cooldownStateResultsCallback = cooldownStateResultsCallback;
    }

    public void Enter()
    {
        Debug.Log("Enter Cooldown");
    }

    public void Execute()
    {
        if (this.cooldownTime >= 0f)
        {
            this.cooldownTime -= Time.deltaTime;
            this.skillCooldownText.text = Math.Ceiling(this.cooldownTime).ToString();
            this.skillImage.fillAmount += 1 / this.cooldownTime * Time.deltaTime;
            this.skillImage.GetComponent<Image>().color = new Color32(255, 255, 255, 20);
        }
        else
        {
            this.skillImage.fillAmount = 1f;
            this.cooldownTime = 0f;
            this.skillCooldownText.text = "";
            this.skillImage.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            var cooldownResults = new CooldownStateResults("teste");

            // this is where should send the information back.
            this.cooldownStateResultsCallback(cooldownResults);
        }
    }

    public void Exit()
    {
        Debug.Log("Exit Cooldown");
    }
}

public class CooldownStateResults
{
    public string test;
    public CooldownStateResults(string test)
    {
        this.test = test;
        // method calls to further process this data
    }
}