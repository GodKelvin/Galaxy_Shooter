using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private AudioSource _audioSrc;
    private float _musicVolume = 1f;

    private VolumeOptions _optionsManager;
    private float _volumeMusic = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _optionsManager = GameObject.Find("OptionsManager").GetComponent<VolumeOptions>();
        //Pegando o audio desse componente(camera)
        _audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //_audioSrc.volume = _musicVolume;
        _volumeMusic = _optionsManager.GetMusicVolume();
        _audioSrc.volume = _volumeMusic;
        //Debug.Log(_volumeEffectSound);
    }

    public void SetMusicVolume(float vol)
    {
        _musicVolume = vol;
    }
}
