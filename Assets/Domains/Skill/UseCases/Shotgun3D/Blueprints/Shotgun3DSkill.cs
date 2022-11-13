using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shotgun3D", menuName = "Skills/Shotgun3D", order = 1)]
public class Shotgun3DSkill : SkillBlueprint
{

    private float life = 5;

    private float spreadDistance = 5f;
    public override void Activate(GameObject parent, Transform transformLocationToInstantiate)
    {
        Debug.Log("Shotgun3D SKILL");
        //Instantiate(parent, transformLocationToInstantiate.position, Quaternion.identity);
        var bullet = Instantiate(parent, transformLocationToInstantiate.position, transformLocationToInstantiate.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transformLocationToInstantiate.forward * 20;
        
        Vector3 newPos2 = new Vector3(transformLocationToInstantiate.position.x +1, transformLocationToInstantiate.position.y, transformLocationToInstantiate.position.z +1);
        var bullet2 = Instantiate(parent, newPos2, transformLocationToInstantiate.rotation);
        //bullet2.GetComponent<Rigidbody>().AddForce(new Vector3(transformLocationToInstantiate.position.x + 1.1f, transformLocationToInstantiate.position.y,transformLocationToInstantiate.position.z + 1.1f)*100);
        bullet2.GetComponent<Rigidbody>().velocity = transformLocationToInstantiate.forward * 20;

        Vector3 newPos3 = new Vector3(transformLocationToInstantiate.position.x -1, transformLocationToInstantiate.position.y, transformLocationToInstantiate.position.z -1);
        var bullet3 = Instantiate(parent, newPos3, transformLocationToInstantiate.rotation);
        //bullet3.GetComponent<Rigidbody>().AddForce(new Vector3(transformLocationToInstantiate.position.x - 1.1f, transformLocationToInstantiate.position.y,transformLocationToInstantiate.position.z - 1.1f)*100);
        bullet3.GetComponent<Rigidbody>().velocity = transformLocationToInstantiate.forward * 20;

        // destrua este objeto após o tempo definido em life. melhorar este código para vir de fora
       // Destroy(parent, life);
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


