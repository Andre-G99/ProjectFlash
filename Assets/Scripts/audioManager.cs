using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicVol, masterVol, sfxVol, uiVol;

    // Start is called before the first frame update
    void Start()
    {   
        loadVolumeSettings(masterVol);
        loadVolumeSettings(musicVol);
        loadVolumeSettings(sfxVol);
        loadVolumeSettings(uiVol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setVolume(Slider slider){

        string exposedParam = slider.name;
        float volume = slider.value;
        
        if (slider.value == -30){
            mixer.SetFloat(exposedParam, -100);
            PlayerPrefs.SetFloat(exposedParam, -100);
            PlayerPrefs.Save();
        } else {
            mixer.SetFloat(exposedParam, volume);
            PlayerPrefs.SetFloat(exposedParam, volume);
            PlayerPrefs.Save();
        }
    }

    private void loadVolumeSettings(Slider slider){
        string exposedParam = slider.name;
        slider.value = PlayerPrefs.GetFloat(exposedParam);
        setVolume(slider);
    }

}
