using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ktp/Decisions/Look")]
public class ktpLookDecision : ktpDecision
{
    public override bool Decide(ktpStateController controller)
    {
        return Look(controller);
    }

    private bool Look(ktpStateController controller){
        Debug.Log("ENTER IN KTP LOOK DECISION");
        ktpFieldOfView fov = controller.GetComponent<ktpFieldOfView>();
        if(fov == null) return false;
        if(fov.visibleTarget != null){
            controller.target = fov.visibleTarget;
            return true;
        }

        return false;
    }
}
