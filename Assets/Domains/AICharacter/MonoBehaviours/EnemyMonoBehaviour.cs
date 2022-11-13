using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonoBehaviour : MonoBehaviour
{
    public EnemyBlueprint enemyBlueprint;
    private string enemyName;
    private int currentHp;
    private int maxHp;
    // Start is called before the first frame update
    void Start()
    {
        enemyName = enemyBlueprint.enemyName;
        maxHp = enemyBlueprint.hp;
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die() {
        Destroy(this.gameObject);
    }

    void takeDamage(int amount) {
        this.currentHp -= amount;
        if(currentHp <= 0) {
            Die();
        }
    }

    public int DoDamage() {
        return enemyBlueprint.attack;
    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Bullet")
        {
            Debug.Log("COLIDIU");
            this.takeDamage(other.gameObject.GetComponent<SkillMonoBehaviour>().DoDamage());
           
            Destroy(other.gameObject);
        }
    }

}
