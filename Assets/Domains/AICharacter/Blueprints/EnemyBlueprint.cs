using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class EnemyBlueprint : ScriptableObject
{
    public string enemyName;
    public int hp;
    public int attack;

}
