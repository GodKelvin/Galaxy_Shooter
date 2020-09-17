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
        _audioSourceExplosion = GetComponent<AudioSource>();
        _audioSourceExplosion.volume = 0.5f;
        _audioSourceExplosion.Play();

        //Destrua esse objeto depois de 4s
        Destroy(this.gameObject, 4f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }
}
