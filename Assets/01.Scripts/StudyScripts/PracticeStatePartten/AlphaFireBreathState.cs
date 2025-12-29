using System;
using Unity.VisualScripting;
using UnityEngine;

public class AlphaFireBreathState : AlphaStateController
{
    [SerializeField] private Collider breathCollider;
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem breathEffect;

    public override void Update()
    {
        if (stateInfo.IsTag("FireBreath"))
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
        breathCollider.enabled = true;
        breathEffect.gameObject.SetActive(true);
        animator.SetTrigger(Breath);
    }

    public override void StateUpdate()
    {
        breathEffect.transform.position = firePoint.position;
        breathEffect.Play();
    }

    public override void ExitState()
    {
        breathCollider.enabled = false;
        breathEffect.gameObject.SetActive(false);
    }
  
    
}
