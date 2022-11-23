using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMonoBehaviour : MonoBehaviour
{
    public CharacterBlueprint characterBlueprint;
    private string characterName;
    private float currentHp;
    private float maxHp;

    void Start()
    {
        characterName = characterBlueprint.characterName;
        maxHp = characterBlueprint.hp;
        currentHp = maxHp;
    }



    void Update()
    {

    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public int DoDamage() {
        return characterBlueprint.basicAttack.attack;
    }

    void takeDamage(int amount)
    {
        this.currentHp -= amount;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Enemy")
        {
            Debug.Log("COLIDIU");
            this.takeDamage(other.gameObject.GetComponent<CharacterMonoBehaviour>().DoDamage());

            Destroy(other.gameObject);
        }
    }

}
