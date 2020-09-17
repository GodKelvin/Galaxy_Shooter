using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeOptions : MonoBehaviour
{
    private AudioSource _audioSrc;
    [SerializeField]
    private float _musicVolume = 1f;

    private float _effectVolume = 1f;
    // Start is called before the first frame update
    private MainCamera _mainCam;
    void Start()
    {
        //_audioSrc = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        //_audioSrc.volume = _musicVolume;
    }

    public void SetMusicVolume(float vol)
    {
        _musicVolume = vol;
        
        /*_mainCam = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        if(_mainCam)
        {
            _mainCam.SetMusicVolume(vol);
        }*/
        
    }

    public void SetEffectVolume(float vol)
    {
        _effectVolume = vol;
    }

    public float GetEffectVolume()
    {
        return _effectVolume;
    }

    public float GetMusicVolume()
    {
        //Debug.Log("OPA1");
        return _musicVolume;
    }
}
