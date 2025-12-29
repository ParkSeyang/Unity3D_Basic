using UnityEngine;

public class PraticeFreeCamController : PraticeAbstractClass
{
    
    public override void UpdatePosition()
    {
        Vector3 inputAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        Vector3 right = transform.right * inputAxis.x;
        Vector3 forward = transform.forward * inputAxis.z;
        
        //상승과 하강까지 처리함
        inputAxis.y += Input.GetKey(KeyCode.Q) ? 1 : 0;
        inputAxis.y += Input.GetKey(KeyCode.E) ? -1 : 0;
        Vector3 up = transform.up * inputAxis.y;
        
        Vector3 moveVector = (forward + up + right).normalized;
        float applySpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : MoveSpeed;
        transform.position += moveVector * applySpeed * Time.deltaTime;
    }
    
    public override void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * HorizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * VerticalSensitivity;

        AngleY += mouseX;
        AngleX -= mouseY;
        
        AngleX = Mathf.Clamp(AngleX, MinAngleX, MaxAngleX);
        
        transform.localRotation = Quaternion.Euler(AngleX, AngleY, 0);
    }
}