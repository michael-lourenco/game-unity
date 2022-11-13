using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "383D", menuName = "Skills/383D", order = 1)]
public class _383DSkill : SkillBlueprint
{

    private float life = 5;

    public override void Activate(GameObject parent, Transform transformLocationToInstantiate)
    {
        Debug.Log("38 3D SKILL");
        //Instantiate(parent, transformLocationToInstantiate.position, Quaternion.identity);
        var bullet = Instantiate(parent, transformLocationToInstantiate.position, transformLocationToInstantiate.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transformLocationToInstantiate.forward * 20;

        // destrua este objeto após o tempo definido em life. melhorar este código para vir de fora
        //Destroy(parent, life);
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
