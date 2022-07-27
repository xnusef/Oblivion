using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{

    [SerializeField] public Slider VolumeSlider;

    public void SaveSettings()
    {
        float volumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
    }

    public void UpdateVolume()
    {
        AudioListener.volume = VolumeSlider.value;        
    }

    public void LoadSettings()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("VolumeValue");
    }
}
