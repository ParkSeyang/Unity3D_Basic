using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class AlphaStateController : MonoBehaviour
{
     public static readonly int Attack = Animator.StringToHash("Attack");
     public static readonly int Breath = Animator.StringToHash("Breath");
     public static readonly int Idle = Animator.StringToHash("Idle");
     
     protected AnimatorStateInfo stateInfo;
     protected Animator animator { get; set; }


     public virtual void Start()
     {
          animator = GetComponent<Animator>(); 
     }

     public virtual void Update()
     {
          // 애니메이션의 시간에 따라서 각 행동상태를 진행한다.
          
          // 애니메이션이 시작하지않았다면
          if (stateInfo.normalizedTime == 0)
          {
               StartState();
            
          }
          // 애니메이션이 진행중이라면
          if (stateInfo.normalizedTime > 0 && stateInfo.normalizedTime < 1)
          {
               StateUpdate();
          }
          // 애니메이션이 끝났다면
          if (stateInfo.normalizedTime >= 1)
          {
               ExitState();
          }
     }

     
     // 이 행동 시작시 호출
     public abstract void StartState();
     // 행동이 진행되고있을때 매 프레임 호출
     public abstract void StateUpdate();
     // 상태가 끝날때 쯤에 호출
     public abstract void ExitState();
     
     
     
     
     
     
}
