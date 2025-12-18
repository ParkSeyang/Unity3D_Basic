using System;
using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   //[SerializeField] private Camera firstCam; 
   //[SerializeField] private Camera ThirdCam;
   //[SerializeField] private Camera FreeSetCam;
    
    [SerializeField] private Transform firstCamPos;
    [SerializeField] private Transform ThirdCamPos;
    [SerializeField] private Transform FreeSetPos;

    [SerializeField] private Transform Target;
    [SerializeField] private float camspeed = 5.0f;
    
   public enum SelectCamera 
   {
       FirstPerson,
       ThirdPerson,
       FreeSetPerson
   }
    
   private SelectCamera cameraType { get; set; } = SelectCamera.FirstPerson;



    private void Awake()
    {
        firstCamPos = GameObject.FindGameObjectWithTag("FristCam").GetComponent<Transform>();
        ThirdCamPos = GameObject.FindGameObjectWithTag("ThirdCam").GetComponent<Transform>();
        FreeSetPos = GameObject.FindGameObjectWithTag("FreeSetCam").GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCamere(SelectCamera.FirstPerson, firstCamPos.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           ChangeCamere(SelectCamera.ThirdPerson, ThirdCamPos.transform);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           ChangeCamere(SelectCamera.FreeSetPerson, FreeSetPos.transform);
        }

     
    }

    
    
   public void ChangeCamere(SelectCamera type, Transform cameraPos)
   {

       switch (type)
       {
           case SelectCamera.FirstPerson:
               firstCamPos.gameObject.SetActive(true);
               ThirdCamPos.gameObject.SetActive(false);
               FreeSetPos.gameObject.SetActive(false);
               
              Target.transform.position = cameraPos.position;
               break;
           
           case SelectCamera.ThirdPerson:
               firstCamPos.gameObject.SetActive(false);
               ThirdCamPos.gameObject.SetActive(true);
               FreeSetPos.gameObject.SetActive(false);
               
               Target.transform.position = cameraPos.position;
               break;
           
           case SelectCamera.FreeSetPerson:
               
               firstCamPos.gameObject.SetActive(false);
               ThirdCamPos.gameObject.SetActive(false);
               FreeSetPos.gameObject.SetActive(true);
               
               Target.transform.position = cameraPos.transform.position;
               break;
           default:
               break;
       }
       
   }
    

}
