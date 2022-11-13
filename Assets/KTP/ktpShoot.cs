using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ktpShoot : MonoBehaviour
{
    public void ShootPlayer(int damage, ktpHealth health) {
        health.DealDamage(damage);
    }

}
