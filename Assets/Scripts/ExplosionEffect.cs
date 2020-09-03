using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private AudioSource _audioSourceExplosion = null;
    private float _speed = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        //Destrua esse objeto depois de 4s
        _audioSourceExplosion = GetComponent<AudioSource>();
        _audioSourceExplosion.volume = 0.5f;
        _audioSourceExplosion.Play();
        Destroy(this.gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
