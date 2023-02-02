using UnityEngine;

public class MicController : MonoBehaviour
{

    public int sampleWindow = 64;
    private AudioClip micClip;
    // Start is called before the first frame update
    void Start()
    {
        MicToAudio();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetAudioFromMic()
    {
        return GetIntensityAudioClip(Microphone.GetPosition(Microphone.devices[0]), micClip);
    }
    public void MicToAudio()
    {
        // récuperer le 1er microphone dans la liste des devices
        string micName = Microphone.devices[0];
        micClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetIntensityAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0)
        {
            return 0;
        }
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalIntensity = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalIntensity += Mathf.Abs(waveData[i]);
        }

        return totalIntensity / sampleWindow;
    }
}
