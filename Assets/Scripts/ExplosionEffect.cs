using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private AudioSource _audioSourceExplosion = null;
    private float _speed = 4.5f;
    
    private VolumeOptions _optionsManager;
    private float _volumeEffect = 1f;
    private AudioSource _audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        _optionsManager = GameObject.Find("OptionsManager").GetComponent<VolumeOptions>();
        _volumeEffect = _optionsManager.GetEffectVolume();
        
        _audioSourceExplosion = GetComponent<AudioSource>();
        _audioSourceExplosion.volume = _volumeEffect;
        _audioSourceExplosion.Play();
        //Destrua esse objeto depois de 4s
        Destroy(this.gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
