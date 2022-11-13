using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "38", menuName = "Skills/38", order = 1)]
public class _38Skill : SkillBlueprint
{

    public override void Activate(GameObject parent, Transform transformLocationToInstantiate)
    {
        Debug.Log("38 SKILL");
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
