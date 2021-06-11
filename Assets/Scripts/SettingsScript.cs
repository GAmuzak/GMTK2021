using UnityEngine;
using UnityEngine.Audio;
public class SettingsScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(2-qualityIndex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
