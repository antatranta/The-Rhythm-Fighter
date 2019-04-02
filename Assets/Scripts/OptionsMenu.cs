using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System.Linq;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public Resolution[] resolutions;

    // Using start so that we can create a dropdown list of resolution based on the monitor's display
    void Start()
    {
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
        int currentResolutionValue = 0;
        List<string> resolutionOptions = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            resolutionOptions.Add(resolutions[i].width + "x" + resolutions[i].height);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionValue = i;
            }
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionValue;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
