using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Characters", order = 1)]
public class CharacterBlueprint : ScriptableObject
{
  public string characterName;

  public float hp;
  
  public float hpperlevel;

  public float mp;

  public float mpperlevel;

  public float movespeed;

  public float armor;

  public float armorperlevel;

  public float spellblock;

  public float spellblockperlevel;

  public float attackrange;

  public float hpregen;

  public float hpregenperlevel;

  public float mpregen;

  public float mpregenperlevel;

  public float crit;

  public float critperlevel;

  public float attackdamage;

  public float attackdamageperlevel;

  public float attackspeedoffset;

  public float attackspeedperlevel;
  public float attackspeed;

  public string lore;

  public string blurb;

  public SkillBlueprint basicAttack;

  public float force;

  public float viewRadius;

  public float viewAngle;

  public LayerMask targets;

  public LayerMask obstacles;

  public Transform visibleTarget;

  public List<SkillBlueprint> skills;


  public virtual void Activate(GameObject parent) {}
  
  public virtual void BeginCooldown(GameObject parent) {}

}

/*      stats: {
        hp: 52;
        hpperlevel: 80,
        mp: 313.7,
        mpperlevel: 35,
        movespeed: 325,
        armor: 22.88,
        armorperlevel: 3.5,
        spellblock: 30,
        spellblockperlevel: 0,
        attackrange: 650,
        hpregen: 5.67,
        hpregenperlevel: 0.55,
        mpregen: 7.4,
        mpregenperlevel: 0.55,
        crit: 0,
        critperlevel: 0,
        attackdamage: 53.66,
        attackdamageperlevel: 2.18,
        attackspeedoffset: 0.1,
        attackspeedperlevel: 4
      }
      */