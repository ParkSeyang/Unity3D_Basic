using System;
using UnityEngine;

public class StudyFreeCamController : MonoBehaviour
{
    // WASD로 이동
    // W는 Forward (바라보는 방향) S는 Back
    // A는 Left, D는 Right
    [Header("Movement Settings")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    [Header("Mouse Settings")] 
    [SerializeField] private float horizontalSensitivity = 1.0f;
    [SerializeField] private float verticalSensitivity = 1.0f;

    [Header("Camera Settings")]
    private float angleX = 0.0f;
    private float angleY = 0.0f;

    private float maxXAngle = 90f;
    private float minXAngle = -90f;
    
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        //{
        //    Vector2 inputAxis = 
        //        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //
        //    Vector3 forward = transform.forward * inputAxis.y;
        //    Vector3 right = transform.right * inputAxis.x;
        //}
       
        Vector3 inputAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        Vector3 forward = transform.forward * inputAxis.z;
        Vector3 right = transform.right * inputAxis.x;
        
        // 상승과 하강까지 처리함
        inputAxis.y += Input.GetKey(KeyCode.Q) ? 1 : 0;
        inputAxis.y += Input.GetKey(KeyCode.E) ? -1 : 0;
        Vector3 up = transform.up * inputAxis.y;
        
        // 이동 관련 로직
        Vector3 moveVector = (up + forward + right).normalized;
        float applySpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        transform.position += moveVector * applySpeed* Time.deltaTime;
    }

    
    
    private void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * horizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * verticalSensitivity;

        Vector3 eulerVector = new Vector3(-mouseY, mouseX, 0.0f);

        // 마우스 X축의 입력에 따라서 수평회전값을 조정한다.
        angleY += mouseX;
        // 마우스 Y축 입력에 따라서 수직회전값을 조정한다.
        angleX -= mouseY;
        
        // Rotate는 한 축을 기반으로 한 회전이다.
        transform.Rotate(eulerVector, Space.World);

        angleX = Mathf.Clamp(angleX, minXAngle, maxXAngle); 
        
        //
        transform.rotation = Quaternion.Euler(angleX, angleY, 0.0f);


    }

}