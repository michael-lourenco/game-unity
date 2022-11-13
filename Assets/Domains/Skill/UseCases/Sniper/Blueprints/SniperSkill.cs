using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sniper", menuName = "Skills/Sniper", order = 1)]
public class SniperSkill : SkillBlueprint
{

    public override void Activate(GameObject parent, Transform transformLocationToInstantiate)
    {
        Debug.Log("SNIPER SKILL");
        Instantiate(parent, transformLocationToInstantiate.position, Quaternion.identity);
    }

    public override void BeginCooldown(GameObject parent)
    {
        return;
    }

    void Start()
    {
    }

    void Update()
    {

    }

    public int DoDamage()
    {
        return this.attack;
    }
}
