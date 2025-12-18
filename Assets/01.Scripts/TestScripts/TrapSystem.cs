using System;
using UnityEngine;

public class TrapSystem :MonoBehaviour
{
    public float Speed;
    public Vector3 StartPosition;
    public Transform Target;
    public float dis;

    private void Awake()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        Trap();
    }

    public void Trap()
    {
        float moveSpeed = Time.deltaTime * Speed;
        
        transform.position = Vector3.Lerp(transform.position, Target.position, moveSpeed);
        Vector3.Distance(StartPosition, Target.position);
        
        
        
        // 시작위치에 현재 위치를 등록





    }

}
