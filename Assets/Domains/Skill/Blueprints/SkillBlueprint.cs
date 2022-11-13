using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skills", order = 1)]
public class SkillBlueprint : ScriptableObject
{
    //public GameObject skillGameObject;
    public Sprite skillSprite;
    public string skillName;
    public int attack;
    public float force;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent, Transform transformLocationToInstantiate) { }
    public virtual void BeginCooldown(GameObject parent) { }

}