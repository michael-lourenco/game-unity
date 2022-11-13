using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CaitCharacter : CharacterBlueprint
{
    public Transform rotationPointTransform;

    public override void Activate(GameObject parent)
    {
        Debug.Log("CAIT PLAYER ");

        Instantiate(parent, rotationPointTransform.position, Quaternion.identity);
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
        return this.basicAttack.attack;
    }
}
