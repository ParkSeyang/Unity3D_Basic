using UnityEngine;

public class StudySoundData : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;

    private float[] spectrumBuffer = new float[512];
    [SerializeField] private Transform ball;
    [SerializeField] private float scaleFator = 1.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float damping = 0.5f;
    void Start()
    {
        
        
    }

    private float goalScale = 1.0f;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            bgm.GetSpectrumData(spectrumBuffer, 0, FFTWindow.Blackman);
            
            // 저음역애의 데이터의 평균치로 ball 트랜스폼의 스케일을 바꿔봅시다.

            int startIdx = 0;
            int endIdx = 64;

            float sum = 0;

            for (int i = startIdx; i <endIdx; i++)
            {
                sum += spectrumBuffer[i];
            }

            goalScale = sum / (endIdx - startIdx);
            
            Vector3 goalScaleVector = Vector3.one * goalScale * scaleFator;
            ball.localScale = Vector3.Lerp(ball.localScale,  goalScaleVector, Time.deltaTime * damping);


            //for (int i=0; i <spectrumBuffer.Length; i++)
            //{
            //    Debug.Log(spectrumBuffer[i]);
            //}


        }
    }
}
