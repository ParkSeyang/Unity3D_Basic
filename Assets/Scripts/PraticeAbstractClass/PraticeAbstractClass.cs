using UnityEngine;

public abstract class PraticeAbstractClass :  MonoBehaviour
{
    // 움직임에 관한 값을 받고있음
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float runSpeed = 10.0f;
    [SerializeField] private float horizontalSensitivity = 1.0f;
    [SerializeField] private float verticalSensitivity = 1.0f;
    
    // 회전 에 관한 값을 받고있음
    [SerializeField] private float angleX = 0.0f;
    [SerializeField] private float angleY = 0.0f;
    [SerializeField] private float maxAngleX = 90;
    [SerializeField] private float minAngleX = -90;
    
    // 캡슐화 작업 프로퍼티로 자식들이 값을 읽어 올수 있게만 선언한다.
    public float MoveSpeed { get { return moveSpeed; } }
    public float RunSpeed { get { return runSpeed; } }
    public float HorizontalSensitivity { get { return horizontalSensitivity; } }
    public float VerticalSensitivity { get { return verticalSensitivity; } }
    // 캡슐화를 잘쓰는법 프로퍼티 get; set;을 응용하면 된다.
    // 읽기만하게하는법
    // public 자료형 변수명 { get { return 변수명;}
    // 클래스내부에서만 값을 읽고 수정하게하는법
    // public 자료형 변수명 { get { return 변수명; } set { 변수명 = value; } }
    // value는 set에서 매개변수역할을해주는 키워드이다 get,set,value;
    public float AngleX { get { return angleX; } set { angleX = value; } }
    public float AngleY { get { return angleY; } set { angleY = value; } }
    
    public float MinAngleX { get { return minAngleX; } }
    public float MaxAngleX { get { return maxAngleX; } }
    
    
    public void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        UpdatePosition();
        UpdateRotation();
    }

    public virtual void UpdatePosition()
    {
          Vector2 inputAxis = 
            new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        Vector3 forward = transform.forward * inputAxis.y;
        Vector3 right = transform.right * inputAxis.x;
        
        Vector3 moveVector = (forward + right).normalized;
        float applySpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
        transform.position += moveVector * applySpeed * Time.deltaTime;
    }



    public virtual void UpdateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * HorizontalSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * VerticalSensitivity;
        
    }



}
