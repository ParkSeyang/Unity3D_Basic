using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FreeSetCamera : MonoBehaviour
{
    [SerializeField] private float mouseSpeed;
    [SerializeField] private Camera freeCamera;
    [SerializeField] private Transform CameraPos;
    
    [Header("Mouse Settings")]
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    
    private void Update()
    {
        CameraMove();
    }

    private void OnDisable()
    {
       //= freeCamera.transform;
    }

    public void CameraMove()
    { 
        float InputX = Input.GetAxisRaw("Horizontal") * mouseSpeed * Time.deltaTime;
        float InputY = Input.GetAxisRaw("Vertical") * mouseSpeed * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed  * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed  * Time.deltaTime;

       // 마우스 X축의 입력에 따라서 수평회전값을 조정한다.
       yRotation += mouseX;
       
       // 마우스 Y축 입력에 따라서 수직회전값을 조정한다.
       xRotation -= mouseY;
       // Mathf.Clamp(value,최소값, 최대값) 만약 값이 최소보다 작다면 최소값을 주고
       // 값 보다 최대값 보다 크다면 최대값을 반환해주는 함수
       // 수직 회전 값을 -90도에서 90도 사이로 제한한다.
       //Vector3 forward, Vector3.back;
       xRotation = Mathf.Clamp(xRotation, -90f, 90f);
       
       freeCamera.transform.Translate(InputX, 0, InputY);
       
       freeCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
       transform.rotation = Quaternion.Euler(0, yRotation, 0);


    }

}
