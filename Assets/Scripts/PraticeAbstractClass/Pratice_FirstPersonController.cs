using System;
using UnityEngine;

public class Pratice_FirstPersonController : PraticeAbstractClass
{
    // 1인칭 캠 위치
    [SerializeField] private Transform cameraTransform; 
    
    //이동은 자기 local 기준 좌표계로 이동
    public override void UpdatePosition()
    {
        Vector2 inputAxis = 
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        Vector3 forward = transform.forward * inputAxis.y;
        Vector3 right = transform.right * inputAxis.x;
        

        Vector3 moveVector = (forward + right).normalized;
        float applySpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : MoveSpeed;
        transform.position += moveVector * applySpeed * Time.deltaTime;
    }

    //회전도 자기 local 기준으로 회전.
    public override void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * HorizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * VerticalSensitivity;
        
        //Rotate함수는 특정 축(Axis)으로 Euler를 더해줌
        //(나중에는 Quaternion단위로 사용함. 사실은 더해주는게 아님. 곱해주는거임)
        transform.Rotate(Vector3.up * mouseX);
        
        // Y축 회전은 플레이어의 회전에 반영하되,
        // X축 회전은 카메라 회적에 반영을 해야합니다.
        cameraTransform.Rotate(Vector3.right * (-mouseY));
    }
}
