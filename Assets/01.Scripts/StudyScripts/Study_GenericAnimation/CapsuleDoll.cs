using System;
using System.Collections;
using UnityEngine;

public class CapsuleDoll : MonoBehaviour
{
    
  [SerializeField] private Renderer capsuleRenderer;
  [SerializeField] private Collider capsuleCollider;
  

  private void Awake()
   {
       capsuleRenderer.GetComponent<Renderer>();
       capsuleCollider.GetComponent<Collider>();
   }





}
