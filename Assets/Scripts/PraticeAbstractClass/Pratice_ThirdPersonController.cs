using UnityEngine;

public class Pratice_ThirdPersonController : PraticeAbstractClass
{
  
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform headPivotTransform;
    
    protected override void Update()
    {
        // 밑의 함수를 추가로 사용하기위해서 부모에 
        // 부모의 이벤트함수(업데이트)를 불러온다.
        // 이렇게안하면 부모의 update와 자식의 update가 겹쳐서 함수가 제대로 실행이안된다.
        base.Update();
        UpdateCameraRotation();
    }

    
    //회전도 자기 local 기준으로 회전.
    public override void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * HorizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * VerticalSensitivity;

        AngleX -= mouseY;
        AngleX = Mathf.Clamp(AngleX, MinAngleX, MaxAngleX);

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            AngleY += mouseX;
        }
        else
        {
            transform.Rotate(Vector3.up, mouseX);
            AngleY = 0.0f;
        }
        
        headPivotTransform.localRotation = Quaternion.Euler(AngleX, AngleY, 0);
    }

    private void UpdateCameraRotation()
    {
        // Transform Method
        //.LookAt() 매개변수로 주어진 Transform을 바라보도록 합니다
        cameraTransform.LookAt(cameraTarget);
    }
}