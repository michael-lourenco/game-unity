using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "SkillHolder", menuName = "ScriptableObjects/SkillHolder", order = 1)]
public class SkillHolderBlueprint : ScriptableObject
{
    public Sprite skillSprite;
    public string skillCooldownText;
    public GameObject skillPrefab;
    public Transform transformLocationToInstantiate;
    private float cooldownTime;
    private float activeTime;
    public KeyCode key;

}