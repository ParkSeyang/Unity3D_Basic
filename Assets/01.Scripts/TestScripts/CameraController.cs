using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    // 사용자 정의 자료형은 언제나 최상단에 둔다.
    public enum SelectCamera 
    {
        FirstPerson,
        ThirdPerson,
        FreeSetPerson,
        End
    }
    
    // private 필도들은 camelCase를 사용한다고 생각하면 됩니다.
    // ex) 첫글자는 소문자, 다음단어부터는 대문자
    
    [SerializeField] private Transform firstCamTransform;
    [SerializeField] private Transform thirdCamTransform;
    [SerializeField] private Transform freeSetTransform;
    [SerializeField] private Transform[] allCamTransforms;
    [SerializeField] private Transform Target;
    [SerializeField] private float camSpeed = 5.0f;
    
    // 모든 프로퍼티는 함수판정 = 파스칼 케이스 사용
    private SelectCamera CameraType { get; set; } = SelectCamera.FirstPerson;
   
    // 고정적으로 사용되는 객체는 Awake로 할당하는방식보다 심플하게 직접할당하는방식이 연산도 덜
    
    private void Awake()
    {
        // 태그를 활용해서 객체를 할당하는방법은 안좋은 방법이다.
        // 단 한번, 엄청 중요한  단 하나의 개체만 찾을때 매우 희귀하게 사용하는게 좋다.
        // 이런 코드가 서비스에 배포되면 안됩니다.
        // 찾는 코드가 들어가야합니다.

        // 배열로 할당하는법
        allCamTransforms = new[] { firstCamTransform, thirdCamTransform, freeSetTransform };

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCamere(SelectCamera.FirstPerson, firstCamTransform.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           ChangeCamere(SelectCamera.ThirdPerson, thirdCamTransform.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           ChangeCamere(SelectCamera.FreeSetPerson, freeSetTransform.transform);
        }

     
    }

    
    
   public void ChangeCamere(SelectCamera type, Transform cameraPos)
   {

       switch (type)
       {
           case SelectCamera.FirstPerson:
               firstCamTransform.gameObject.SetActive(true);
               thirdCamTransform.gameObject.SetActive(false);
               freeSetTransform.gameObject.SetActive(false);
               
              Target.transform.position = cameraPos.position;
               break;
           
           case SelectCamera.ThirdPerson:
               firstCamTransform.gameObject.SetActive(false);
               thirdCamTransform.gameObject.SetActive(true);
               freeSetTransform.gameObject.SetActive(false);
               
               Target.transform.position = cameraPos.position;
               break;
           
           case SelectCamera.FreeSetPerson:
               
               firstCamTransform.gameObject.SetActive(false);
               thirdCamTransform.gameObject.SetActive(false);
               freeSetTransform.gameObject.SetActive(true);
               
               Target.transform.position = cameraPos.transform.position;
               break;
           default:
               break;
       }
       
   }

   void allCamTransform()
   {
       for (int i = 0; i < allCamTransforms.Length; i++)
       {
           allCamTransforms[i].gameObject.SetActive(false);
       }
   }

}
