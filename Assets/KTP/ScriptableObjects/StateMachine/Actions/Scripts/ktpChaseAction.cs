using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ktp/Actions/Chase")]
public class ktpChaseAction : ktpAction
{
    public override void Act(ktpStateController controller)
    {
        Chase(controller);
    }

    private void Chase(ktpStateController controller)
    {
        Debug.Log("ENTER IN KTP CHASE ACTION");
        //ktpCharAI enemy = controller.GetComponent<ktpCharAI>();

        //enemy.currentState = CurrentState.Attack;
        controller.agent.speed = controller.ktpCharAIStats.runSpeed;

        ktpFieldOfView fov = controller.GetComponent<ktpFieldOfView>();
        if (fov == null) return;
        if (fov.visibleTarget != null)
        {
            controller.agent.destination = controller.target.position;
            controller.lastKnownTargetPosition = controller.target.position;
            controller.agent.Resume();
        }
        else{
            controller.agent.destination = controller.lastKnownTargetPosition;
            controller.agent.Resume();
        }
    }
}
