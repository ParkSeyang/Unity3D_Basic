using System;
using UnityEngine;
using UnityEngine.Audio;

public class StudyAudioClass : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource sfx;

    [SerializeField] private AudioClip roarSound;
    [SerializeField] private AudioMixerGroup bgmchanel;
    [SerializeField] private AudioMixer mixer;

    [SerializeField] private SFX_Templete templete;
    
    private void Awake()
    {
        /*
         * .Play(); -> 끝까지 재생하고, Loop 체크가 되어있으면 반복재생한다.
         * .PlayOneShot(); -> 매개변수의 오디오클립(오디오 제네레이터)을 딱 한번만 재생하고 끝.
         * .PlayDelayed(); -> 지연해서 재생
         */
        // bgm.Play();
        // bgm.PlayDelayed();
        
        
        // bgm.PlayOneShot();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sfx.PlayOneShot(templete.clipA);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sfx.PlayOneShot(templete.clipB);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            sfx.PlayOneShot(templete.clipC);
        }

        // if (Input.GetKeyDown(KeyCode.Alpha1))
      // {
      //     bgm.Play();
      // }

      // if (Input.GetKeyDown(KeyCode.Alpha2))
      // {
      //     bgm.PlayDelayed(3.0f);
      // }

      // if (Input.GetKeyDown(KeyCode.Alpha3))
      // {
      //     bgm.PlayOneShot(roarSound);
      // }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            mixer.SetFloat("BGMSound", 5.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            mixer.SetFloat("BGMSound", -80.0f);
        }
        
        
    }
}
