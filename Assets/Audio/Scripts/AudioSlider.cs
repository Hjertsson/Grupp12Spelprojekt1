using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;

    public void UpdateValue(float value)
    {
        value = Mathf.Clamp(value,0.001f,1f);
        audioMixer.SetFloat("Master",Mathf.Log10(value)*20);
    }
}
