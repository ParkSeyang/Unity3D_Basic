using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    // 상태들을 불러와서 유저의 입력에따라 행동을 제어해야한다.
    // 근데 어떻게하지???
    
    // 각 상태 행동들을 추상클래스로 분리를했지만 protected로 되어있어 클래스를 불러서 함수를사용할수가없다.
    
    // 코루틴없이 사용할려고했는데 쉽지않은것같다 일단 계속 고민을해보자.
    
   // AlphaClawAttackState clawAttackState;
   // AlphaFireBreathState fireBreathState;
   // AlphaIdleState idleState;

   // public void ChangeState(AlphaStateController stateController)
   // {
   // }
   // 생각해보니 애초에 클래스가 public인데 protected로 추상클래스를 만들어서 캡슐화의 의미가없는거같다.
   // 걍 pubilc으로 바꿔서 해도될꺼같은데 내가 작성한 코드방식이 좀 엉성한거같다.

  // List<Type> states = new List<Type>();
  // public void Awake()
  // {
  //     states.Add(typeof(AlphaClawAttackState));
  //     states.Add(typeof(AlphaFireBreathState));
  //     states.Add(typeof(AlphaIdleState));
  //     
  // }

  // public void ChangeState(AlphaStateController controller)
  // {
  //     
  // }


}
