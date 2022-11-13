using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMonoBehaviour : MonoBehaviour
{
    public SkillBlueprint skill;
    public Vector3 mousePos;
    public Camera mainCamera;
    public Rigidbody rb;
    public float force;

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual int DoDamage()
    {

        return this.skill.attack;
    }

}
