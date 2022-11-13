using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bomb3D", menuName = "Skills/Bomb3D", order = 1)]
public class Bomb3DSkill : SkillBlueprint
{

    private float life = 5;

    public override void Activate(GameObject parent, Transform transformLocationToInstantiate)
    {
        Debug.Log("Bomb3D SKILL");
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
