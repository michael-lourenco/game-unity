using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ktp/ktpCharAIStats")]
public class ktpCharAIStats : ScriptableObject
{
    public float walkSpeed;
    public float runSpeed;
    public float attackRate;
    public int damage;
    public int searchDuration;
    public int searchingTurnSpeed;

    public int stoppingDistance;

    public float hp;
    
}
