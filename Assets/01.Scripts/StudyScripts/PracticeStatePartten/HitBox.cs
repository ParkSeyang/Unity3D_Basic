using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class HitBox : MonoBehaviour
{
    [SerializeField] private Collider hitBoxCollider;
    [SerializeField] private Renderer capsuleRenderer;

    private void OnEnable()
    {

    }

    private void Awake()
    {
        
    }

    private void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log(gameObject.name);

       // Material currentMaterial = capsuleRenderer.material;

       // Color OriginalColor = currentMaterial.color;
       // Color HitColor = Color.red;

       // float checkTime = 0.0f;
       // checkTime += Time.deltaTime;
       // currentMaterial.color = Color.Lerp(OriginalColor, HitColor, checkTime);
        
        
    }

    
}
