using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : UIPanel
{
    [SerializeField] private Slider soundVolumeSlider;
    public void SetSoundVolume()
    {
        SoundController.Instance.SetSoundVolume(soundVolumeSlider.value);
    }

}
