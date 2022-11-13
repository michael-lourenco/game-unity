using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Skills/Bullet", order = 1)]
public class BulletSkill : SkillBlueprint
{

    public override void Activate(GameObject parent, Transform transformLocationToInstantiate)
    {
        Debug.Log("BULLET SKILL");
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
