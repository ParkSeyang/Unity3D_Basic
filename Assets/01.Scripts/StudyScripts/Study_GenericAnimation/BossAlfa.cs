using System;
using UnityEngine;

public class BossAlfa : MonoBehaviour
{
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Breath = Animator.StringToHash("Breath");
    [SerializeField] private Transform firePoint;
    [SerializeField] private ParticleSystem breathEffect;
    private Animator Animator { get; set; }

    [SerializeField] private Collider ScratchCollider;
    [SerializeField] private Collider breathCollider;
    
    
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        
        // ParticleSystem이란?
        // 각종 연출과 효과에 사용되는 컴포넌트
        // 입자를 이용한 각종 Effect들이 사용된다고 생각하면 된다.
        // 몇백, 몇천개의 작은 입자들을 사용해서 화염이나 번개같은
        // 그래픽효과를 만드는데에 사용이 됩니다.
        // .Play(); -> 파티클을 재생시키는 함수
        // .isPlaying(); -> 재생중이니? 물어볼수있는 프로퍼티
       // breathEffect.Play();
       // breathEffect.isPlaying();
       breathCollider.enabled = false;
       ScratchCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Animator.SetTrigger(Attack);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Animator.SetTrigger(Breath);
            StartBreath();
            // 애니메이션
        }

        if (isBreathing)
        {
            breathEffect.transform.position = firePoint.position;
        }

    }
    
    private bool isBreathing = false;
    
    private void StartBreath()
    {
        breathEffect.gameObject.SetActive(true);
        breathEffect.transform.SetParent(firePoint);
        breathEffect.Play();
        breathCollider.enabled = true;

    }

    private void EndBreath()
    {
        isBreathing = false;
        breathCollider.enabled = false;
    }

    private void StartScratch()
    {
        ScratchCollider.enabled = true;
    }

    private void EndScratch()
    {
        ScratchCollider.enabled = false;
    }


}
