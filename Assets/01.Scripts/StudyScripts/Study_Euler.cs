using System;
using UnityEngine;

public class Study_Euler : MonoBehaviour
{
    [System.Serializable]
    public struct RotationInfo
    {
        public Vector3 Axis;
        public float Speed;
        public bool IsLocal;
    }
    
    public RotationInfo rotationInfo;

    void Update()
    {
        // deltAngle = 한프레임에 회전할 회전량을 구해줍니다.
        // angle 이니까 각도라고 생각하면 됩니다.
        // rotationInfo.Speed가 결정하는 것은 "1초에 몇도 만큼 회전하는가" 입니다. 
        float deltAngle = rotationInfo.Speed * Time.deltaTime;
        
        // 각도를 구했으니 회전축에 적용을 해서 Tranform에 반영할 Euler 값을 구해줍니다.
        
        Vector3 deltaEuler = rotationInfo.Axis.normalized * deltAngle;
        
        // IsLocal이 true일 경우는 자기자신. false일 경우에는 World 기준의 축으로 설정.
        Space axisSpace = rotationInfo.IsLocal ? Space.Self : Space.World;
        
        transform.Rotate(deltaEuler, axisSpace);

    }
}
