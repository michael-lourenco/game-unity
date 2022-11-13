using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunMonoBehaviour : SkillMonoBehaviour
{

    public override void Start()
    {
        this.force = this.skill.force;

        /*mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        this.rb = GetComponent<Rigidbody2D>();
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = this.mousePos - transform.position;
        Vector3 rotation = transform.position - this.mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * this.force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);*/
    }

    public override void Update()
    {

    }

    public override int DoDamage()
    {
        return this.skill.attack;
    }

}
