using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeOptions : MonoBehaviour
{
    private AudioSource _audioSrc;
    [SerializeField]
    private float _musicVolume = 1f;

    [SerializeField]
    private float _effectVolume = 1f;

    [SerializeField]
    private AudioClip _clipSoundPowerUp = null;
    
    public void SetMusicVolume(float vol)
    {
        _musicVolume = vol;
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
        return _musicVolume;
    }

    public void TesteSoundEffect()
    {
        AudioSource.PlayClipAtPoint(_clipSoundPowerUp, Camera.main.transform.position, _effectVolume);
    }
}
