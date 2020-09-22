using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //movimentando para fora da cena 3m/s
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerUpID = -1;//0 == Triple Shot, 1 == Speed Boost, 2 == Shields

    //private AudioSource _audioSourcePowerUp;
    //Utilizamos um clip para armazenar o audio, caso contrario, o audio seria destruido com o objeto
    [SerializeField]
    private AudioClip _clipSoundPowerUp = null;

    private VolumeOptions _optionsManager;
    private float _volumeEffect = 1f;

    private GameManager _gameManager;

    void Start()
    {
        _optionsManager = GameObject.Find("OptionsManager").GetComponent<VolumeOptions>();
        _volumeEffect = _optionsManager.GetEffectVolume();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //_audioSourcePowerUp = GetComponent<AudioSource>();
        PowerUpSpawn();
    }


    // Update is called once per frame
    void Update()
    {
        PowerUpMovement();
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Verifico se o que eu colidi eh o Player
        if(other.tag == "Player")
        {
            //Access the player
            Player player = other.GetComponent<Player>();

            //Se o player foi encontrado
            if(player != null)
            {
                if(_powerUpID == 0)
                {
                    //Enable triple shot
                    player.TripleShotPowerUpOn();
                }
                else if(_powerUpID == 1)
                {
                    //Enable Speed boost
                    player.SpeedBoostPowerUpOn();
                }
                else if(_powerUpID == 2)
                {
                    //Enable shield
                    player.ShieldPowerUpOn();
                }
            }
            //destroy this powerup
            //O que vai tocar, posicao na tela, volume
            AudioSource.PlayClipAtPoint(_clipSoundPowerUp, Camera.main.transform.position, _volumeEffect);
            Destroy(this.gameObject);
        }
    }

    private void PowerUpSpawn()
    {
        float yPosition = 5.7f;
        float xPosition = Random.Range(-7.44f, 7.59f);
        transform.position = new Vector3(xPosition, yPosition, 0);
       
    }

    private void PowerUpMovement()
    {
        //Fazendo-o cair em tempo real 3m/s
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
}
