using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ktp/Decisions/VisibleTargetDecison")]
public class ktpVisibleTargetDecision : ktpDecision
{
    public override bool Decide(ktpStateController controller)
    {
        return TargetNotVisible(controller);
    }

    private bool TargetNotVisible(ktpStateController controller){
        Debug.Log("ENTER IN KTP VISIBLE TARGET DECISION");
        controller.transform.Rotate(0, controller.ktpCharAIStats.searchingTurnSpeed * Time.deltaTime, 0);
        return controller.HasTimeElapsed(controller.ktpCharAIStats.searchDuration);
    }
}
