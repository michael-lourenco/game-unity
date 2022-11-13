using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ktpHealth : MonoBehaviour
{
    public int health = 100;

    private void Update()
    {
        if (health <= 0 && GetComponent<PlayerMovement>())
            Die();
    }

    public void DealDamage(int damage)
    {
        if (health > 0)
            health -= damage;
    }

    public void Die()
    {
        Destroy(GetComponent<PlayerMovement>());
        print("You dead");
    }
}
