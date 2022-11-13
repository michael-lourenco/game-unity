using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillHolderMonoBehaviour : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    public Image skillImage;
    public TextMeshProUGUI skillCooldownText;
    public GameObject skillPrefab;
    public Transform transformLocationToInstantiate;
    private float cooldownTime;
    private float activeTime;
    public SkillMonoBehaviour skillMonoBehaviour;
    public KeyCode key;

    void Start()
    {
        skillCooldownText.text = "";
        skillMonoBehaviour = skillPrefab.GetComponent<SkillMonoBehaviour>();

        //if you want that skills start ready change the states down
        /*
        this.stateMachine.ChangeState(
            new ReadyState(
                this.skillMonoBehaviour, 
                this.skillPrefab,
                this.transformLocationToInstantiate,
                this.activeTime,
                this.skillImage,
                this.key,
                this.UpdateReadyState
            )
        );
        */


        this.cooldownTime = skillMonoBehaviour.skill.cooldownTime;

        this.stateMachine.ChangeState(
            new CooldownState(
                this.skillMonoBehaviour,
                this.skillPrefab,
                this.transformLocationToInstantiate,
                this.activeTime,
                this.skillImage,
                this.cooldownTime,
                skillCooldownText,
                this.UpdateCoolDown
            )
        );
    }

    void Update()
    {
        this.stateMachine.ExecuteStateUpdate();
    }

    void UpdateReadyState(ReadyStateResults readyStateResults)
    {
        this.activeTime = skillMonoBehaviour.skill.activeTime;
        this.cooldownTime = skillMonoBehaviour.skill.cooldownTime;
        this.skillImage.fillAmount = 0f;

        this.stateMachine.ChangeState(
            new ActiveState(
                this.skillMonoBehaviour,
                this.skillPrefab,
                this.transformLocationToInstantiate,
                this.activeTime,
                this.skillImage,
                this.cooldownTime,
                this.UpdateActiveState
            )
        );

    }

    void UpdateActiveState(ActiveStateResults activeStateResults)
    {
        this.stateMachine.ChangeState(
            new CooldownState(
                this.skillMonoBehaviour,
                this.skillPrefab,
                this.transformLocationToInstantiate,
                this.activeTime,
                this.skillImage,
                this.cooldownTime,
                skillCooldownText,
                this.UpdateCoolDown
            )
        );
    }

    void UpdateCoolDown(CooldownStateResults cooldownStateResults)
    {
        this.stateMachine.ChangeState(
            new ReadyState(
                this.skillMonoBehaviour,
                this.skillPrefab,
                this.transformLocationToInstantiate,
                this.activeTime,
                this.skillImage,
                this.key,
                this.UpdateReadyState
            )
        );
    }

}
