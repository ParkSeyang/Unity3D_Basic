using System;
using UnityEngine;

public class AlphaClawAttackState : AlphaStateController
{
    [SerializeField] private Collider ClawCollider;

    public override void Update()
    {
        if (stateInfo.IsTag("ClawAttack"))
        {
            if (stateInfo.normalizedTime == 0)
            {
                StartState();
            }
            if (stateInfo.normalizedTime > 0 && stateInfo.normalizedTime < 1)
            {
                StateUpdate();
            }

            if (stateInfo.normalizedTime >= 1)
            {
                ExitState();
            }
        }
    }

    public override void StartState()
    {
        animator.SetTrigger(Attack);
    }

    public override void StateUpdate()
    {
        ClawCollider.enabled = true;
    }

    public override void ExitState()
    {
        ClawCollider.enabled = false;
    }

  
}
