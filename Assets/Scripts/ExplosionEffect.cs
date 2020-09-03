using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private AudioSource _audioSourceExplosion;

    // Start is called before the first frame update
    void Start()
    {
        //Destrua esse objeto depois de 4s
        _audioSourceExplosion = GetComponent<AudioSource>();
        _audioSourceExplosion.Play();
        Destroy(this.gameObject, 4f);
    }
}
