using Unity.VisualScripting;
using UnityEngine;

public class AlphaIdleState : AlphaStateController
{
    
    public override void StartState()
    {
        animator.SetTrigger(Idle);
    }

    public override void StateUpdate()
    {
        
    }

    public override void ExitState()
    {
        
    }

 
    
}
