using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ktp/Actions/Patrol")]
public class ktpPatrolAction : ktpAction
{
    public override void Act(ktpStateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(ktpStateController controller){
        Debug.Log("ENTER IN KTP PATROL ACTION");
        ktpEnemy enemy = controller.GetComponent<ktpEnemy>();
        enemy.currentState = CurrentState.Patrol;
        controller.agent.speed = controller.enemyStats.walkSpeed;
        controller.agent.destination = controller.wayPoints[controller.nextWaypoint].position;
        controller.agent.Resume();
        if(controller.agent.remainingDistance <= controller.agent.stoppingDistance && !controller.agent.pathPending){
            controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.wayPoints.Count;
        }
    }
}
