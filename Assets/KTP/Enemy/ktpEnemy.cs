using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum CurrentState
{
    Patrol,
    Attack,
}
public class ktpEnemy : MonoBehaviour
{
    public ktpAnimateCharacter animate;
    public NavMeshAgent agent;
    public CurrentState currentState;

    private void Awake()
    {
        animate = GetComponent<ktpAnimateCharacter>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Mathf.Abs(agent.velocity.x) > 0.2f || Mathf.Abs(agent.velocity.x) > 0.2f)
        {
            if (currentState == CurrentState.Attack)
            {
                animate.AnimateRun(true);
            }
            else if (currentState == CurrentState.Patrol)
            {
                animate.AnimateWalk(true);
            }
        }
        else
        {
            animate.AnimateRun(false);
        }
    }
}
