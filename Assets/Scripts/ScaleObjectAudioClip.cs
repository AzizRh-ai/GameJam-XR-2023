using UnityEngine;

public class ScaleObjectAudioClip : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private Vector3 minScale;
    [SerializeField] ParticleSystem particle;
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private MicController detector;

    public float loudSensibility = 100;
    public float threshold = 0.1f;

    // Start is called before the first frame update
    void Update()
    {
        float loudness = detector.GetAudioFromMic() * loudSensibility;
        if (loudness <= threshold)
        {
            loudness = 0;
            //particle.Stop();
        }
        /* else if (loudness > threshold)
         {
            // particle.Play();
         }*/
        transform.localScale = new Vector3(0, loudness * Time.deltaTime, 0);
        // transform.localScale = Vector3.Lerp(minScale, maxScale, loudness) * Time.deltaTime;
    }
}
