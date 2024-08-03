using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public string parameter;

    [SerializeField] private UI_VolumeSlider[] volumeSettings;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float multuplier;

    public void SlierValue(float _value) => audioMixer.SetFloat(parameter, Mathf.Log10(_value) * multuplier);

    public void LoadSlider(float _value)
    {
        if (_value >= 0.001f)
            slider.value = _value;
    }

    public void LoadData(GameData _data)
    {
        foreach (KeyValuePair<string, float> pair in _data.volumSettings)
        {
            foreach (UI_VolumeSlider item in volumeSettings)
            {
                if (item.parameter == pair.Key)
                    item.LoadSlider(pair.Value);
            }
        }
    }

    public void SaveData(ref GameData _data)
    {
        _data.volumSettings.Clear();

        foreach (UI_VolumeSlider item in volumeSettings)
        {
            _data.volumSettings.Add(item.parameter, item.slider.value);
        }
    }
}
