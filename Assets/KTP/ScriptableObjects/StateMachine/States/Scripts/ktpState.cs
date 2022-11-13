using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ktp/State")]
public class ktpState : ScriptableObject
{
    public ktpAction[] actions;
    public ktpTransition[] transitions;
    public Color gizmoColor = Color.blue;

    public void UpdateState(ktpStateController controller){
        ExecuteActions(controller);
        CheckForTransitions(controller);
    }

    private void ExecuteActions(ktpStateController controller){
        foreach(var action in actions){
            action.Act(controller);
        }
    }

    private void CheckForTransitions(ktpStateController controller){
        foreach(var transition in transitions){
            bool decision = transition.decision.Decide(controller);
            if(decision)
                controller.TransitionToState(transition.trueState);
            else    
                controller.TransitionToState(transition.falseState);
        }
    }
}
