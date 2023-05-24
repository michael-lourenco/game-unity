using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ktp/Actions/Attack")]
public class ktpAttackAction : ktpAction
{
    public override void Act(ktpStateController controller)
    {
        Attack(controller);
    }

    private void Attack(ktpStateController controller)
    {
        Debug.Log("ENTER IN KTP ATTACK ACTION");
        if (controller.enemy != null && controller.enemy.activeSelf)
        {

            //ktpCharAI enemy = controller.GetComponent<ktpCharAI>();
           // enemy.currentState = CurrentState.Attack;
            Debug.Log("ATACOU!!!");
            
           
            
            // FieldOfView fov = controller.GetComponent<FieldOfView>();
            // if (fov == null) return;
            // if (!controller.stateBoolVariable)
            // {
            //     controller.stateTimeElapsed = controller.ktpCharAIStats.attackRate;
            //     controller.stateBoolVariable = true;
            // }
            // Debug.Log("FIELD OR VIEW 1");
            // if(fov.visibleTarget != null){
            //     Debug.Log("FIELD OR VIEW 2");
            //     /*if(controller.HasTimeElapsed(controller.ktpCharAIStats.attackRate)){
            //         // controller.shoot.ShootPlayer(controller.ktpCharAIStats.damage, controller.target.GetComponent<Health>());
            //         Debug.Log("Atirou");
            //     }*/
            //     Debug.Log("ATIROU");
            //             //Make sure enemy doesn't move
            //     controller.agent.SetDestination(controller.transform.position);

            //     controller.transform.LookAt(controller.player.transform);

            //     if (!controller.alreadyAttacked)
            //     {
            //         Debug.Log("FIELD OR VIEW 3");
            //         ///Attack code here
            //         Rigidbody rb = Instantiate(controller.projectile, controller.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //         rb.AddForce(controller.transform.forward * 32f, ForceMode.Impulse);
            //         rb.AddForce(controller.transform.up * 8f, ForceMode.Impulse);
            //         ///End of attack code

            //         controller.alreadyAttacked = true;
            //         //Invoke(nameof(ResetAttack), timeBetweenAttacks);
            //     }
            // }

            //controller.agent.SetDestination(controller.transform.position);

           // controller.transform.LookAt(controller.enemy.transform);

            if (!controller.alreadyAttacked)
            {
                SkillMonoBehaviour skillToUse = controller.projectile.GetComponent<SkillMonoBehaviour>();

                ///Attack code here
                skillToUse.skill.Activate(controller.projectile, controller.pointToInstantiateFire);
                ///End of attack code

                controller.alreadyAttacked = true;
                controller.Invoke(nameof(controller.ResetAttack), skillToUse.skill.cooldownTime);
            }
        } else if(GameObject.FindGameObjectWithTag(controller.tagToFind)){
             controller.enemy = GameObject.FindGameObjectWithTag(controller.tagToFind);
        }else{
            controller.enemy = null;
        }
    }

}
