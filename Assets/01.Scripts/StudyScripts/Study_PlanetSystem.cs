using System;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class Study_PlanetSystem : MonoBehaviour
{
    public GameObject[] PlanetPrefabs;
    public Transform EarthTransform;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPlanet();
        }
    }

    /* delegate 란?
     * C / C++ 의 함수 포인터와 비슷한 개념으로, 메서드 파라미터와 리턴 타입에 대한 정의를 한후,
     * 동일한 파라미터 와 리턴 타입을 가진 메서드를 서로 호호나해서 불러 쓸 수 있는 기능.
     *
     * Delegate로 메서드 대리자를 선언해주고 원하는 메서드를 참조시킬 수 있습니다.
     *
     * 쉽게 말하면, 함수를 보관하는 통을 만들고(대리자선언) 그 통안에 함수를 넣고 나중에 통을 가져와서 함수를 실행시키는 방식입니다.
     * 한 마디로 표현,, "함수를 대입할 수 있는 변수" / "대리자"
     * 이 변수에는 실질적으로 함수가 대입되어 있으므로, 변수를 실행하지만, 대입한 함수가 실행된다.
     *
     * 선언 구문
     * => 접근제한자 delegate 대상 메서드의 반환타입 타입명(대상 메서드의 매개변수들..);
     * (예시에선 접근제한자 생략)
     * delegate void Type1(void);		// void func1(void)
     * delegate int Type2(int, int);	// int func2(int, int)
     * delegate string Type3(double);	// string func3(double)
     * delegate float Type4(int);		// float func4(int)
     */
    public delegate void TestDelegate();

    public TestDelegate myTest;

    public void Start()
    {
        myTest = MyTest;
        myTest();
        myTest += SpawnPlanet;
        myTest();
        myTest -= MyTest;
        myTest();
        
    }

    private void MyTest()
    {
        int sum1 = 10;
        int sum2 = 20;
        
        int result = sum1 + sum2;
        
        Debug.Log(result);
        
    }

    private void SpawnPlanet()
    {
        var trans = new GameObject("new Planet Axis").transform;
        trans.SetParent(EarthTransform);
        
        Vector3[] axisRange = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
        Vector3 randAxis = axisRange[Random.Range(0, axisRange.Length)];
        float randDistance = Random.Range(1.5f, 5);
        float RandScale = Random.Range(0.2f, 1.0f);
        
        // 1. PlanetPrefabs 배열에서 임의의 개체 하나를 선택
        GameObject RandomPlanet = PlanetPrefabs[Random.Range(0, PlanetPrefabs.Length)];
       
        // 2. Instantiate() 함수를 이용해서 새 인스턴스(이하 새 행성)를 할당.
        GameObject CreatePlanet = Instantiate(RandomPlanet, trans);
        
        // 4. 새 행성의 localPosition을 randAxis * randDistance으로 할당 
        CreatePlanet.transform.localPosition = randAxis * randDistance;
        // 5. 새 행성의 localScale에 randScale을 대입
        CreatePlanet.transform.localScale = new Vector3(RandScale, RandScale, RandScale);
        
        // 5. trans의 gameObject에 동적으로 Study_Euler 클래스를 대입한다.
        // var rotator = trans.gameObject.AddComponent<Study_Euler>();
        Study_Euler rotator = trans.gameObject.AddComponent<Study_Euler>();
        
        // 6. 인스턴스(Study_Euler)의 회전 정보(RotationInfo)를 랜덤으로 설정해주기
        rotator.rotationInfo.Axis = axisRange[Random.Range(0, axisRange.Length)];
        rotator.rotationInfo.Speed = Random.Range(0.0f, 100.0f);
        rotator.rotationInfo.IsLocal = (Random.Range(0, 2) == 0);
        

    }
    

}