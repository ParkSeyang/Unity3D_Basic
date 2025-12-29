using UnityEngine;

public class Study_Camera : MonoBehaviour
{
   // Camera의 핵심 프로퍼티(필드)
   // - Field of View(FOV) / Size : 얼마나 넓은 시야를 가질지 결정합니다.
   // 값이 클수록 넓은 범위를 렌더링 합니다. -> 더많은 연산이 필요함.
   // 예시)Sniper Rifle을 만들때 사용 가능
   // - Clipping Planes : 카메라가 렌더링할 가장 가까운 거리와 가장 먼 거리를 
   // 설정 합니다. 가까움(Near), 먼(Far)
   // 예시) 원경의 거리 제한을 통해 최적화 할때 사용합니다.
   // - Culling Mask : 특정 레이어(Layer)의 오브젝트만 선택적으로
   // 렌더링 할 수 있게 합니다.
   // - Priority(Depth) : 씬에 여러대의 카메라가 있을때 렌더링의 순서를 결정합니다.
   // - ViewPortRect : 카메라의 최종 렌더링 결과를 화면에 어떤 영역에
   // 어떻게 배치할지 결정합니다.
   
   
   void Update()
   {
      if (Input.GetKey(KeyCode.Alpha1))
      {
         Camera.main.fieldOfView += 1f;
      }
      


   }


}