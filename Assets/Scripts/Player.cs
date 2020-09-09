using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Mesmo com  atributo privado, mostra-lo no inspector
    [SerializeField]
    private float _speed = 7.5f;

    //Laser of player (adicionado manualmente atraves do Prefab)
    [SerializeField]
    private GameObject _laserPrefab = null;
    [SerializeField]
    private GameObject _tripleShotPrefab = null;

    //Variaveis de controle de tiro
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _canFire = 0.0f;

    //PowerUps Controller Variables
    public bool canTripleShot = false;
    //public bool speedBoost = false;
    [SerializeField]
    private float _moreSpeed = 1;

    [SerializeField]
    private int _life = 3;

    [SerializeField]
    private GameObject _explosionPrefab = null;

    [SerializeField]
    private bool _shieldEnabled = false;

    [SerializeField]
    private GameObject _shieldGameObject = null;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;

    private AudioSource _audioSourceShoot;

    [SerializeField]
    private GameObject[] _engines = null;
    
    private bool _leftEngineFail = false;
    private bool _rightEngineFail = false;

    private int _firstDamage = -1;
    private int _secondDamage = -1;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        //_uiManager != null
        if(_uiManager)
        {
            _uiManager.UpdateLives(_life);
        }
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Quando o jogo eh iniciado, informo que ja pode dar spawn nos objetos (powerUps, enemys)
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();


        //Se nao for nulo
        if(_spawnManager)
        {
            _spawnManager.StartSpawnRoutines();
        }

        //Ja estou dentro do player, entao so pego a fonte de audio que ele tem
        _audioSourceShoot = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Player_movement();
                                          //Left click mouse(0)
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
       
    }

    //----------Metodos do Player----------//
    public void PlayerSpawn()
    {
        //Debug.Log("X pos: " + transform.position.x);
        transform.position = new Vector3(0, -3, 0);
    }
    private void Shoot()
    {
        if(Time.time > _canFire)
        {
            _audioSourceShoot.Play();
            if(canTripleShot)
            {
                /*
                //center
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.07f, 0), Quaternion.identity);
                //left
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.78f, -0.226f, 0), Quaternion.identity);
                //right
                Instantiate(_laserPrefab, transform.position + new Vector3(0.78f, -0.226f, 0), Quaternion.identity);
                */
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);

            }
            else
            {
                //Instanciando o laser acima da posicao do jogador (eixo Y), na rotacao padrao (Quaternion)
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.07f, 0), Quaternion.identity);

              
            }

            //Faco o player esperar o tempo delimitado para o proximo tiro
            //Time.time contem o tempo em segundos da execucao do jogo
            _canFire = Time.time + _fireRate;
            //Debug.Log(Time.time + ", "+ canFire);
        }
    }

    private void Player_movement()
    {
        
        //Debugs
        //Debug.Log("X pos: " + transform.position.x + ", Y pos: " + transform.position.y);
        //Debug.Log("Y pos: " + transform.position.y);
        
        //Move player to left and right
        float horizontalInput = Input.GetAxis("Horizontal");
        //new Vector3(1,0,0) * 1(TD) * inputUser(1 or -1) * speed * _moreSpeed (if PowerUpOn(Boost))
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * _speed * _moreSpeed);

        //Move player to up and down
        float verticalInput = Input.GetAxis("Vertical");
        //new Vector3(0,1,0) * 1(TD) * inputUser(1 or -1) * speed * _moreSpeed (if PowerUpOn(Boost))
        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * _speed * _moreSpeed);

        //Delimite space to moving player
        float max_x_range = 8.08f;
        float min_x_range = -8.02f;
        float max_y_range = 3.91f;
        float min_y_range = -3.97f;

        if(transform.position.x < min_x_range)
        {
            transform.position = new Vector3(min_x_range, transform.position.y, 0);
        }
        else if(transform.position.x > max_x_range)
        {
            transform.position = new Vector3(max_x_range, transform.position.y, 0);
        }
        
        if(transform.position.y < min_y_range)
        {
            transform.position = new Vector3(transform.position.x, min_y_range, 0);
        }
        else if(transform.position.y > max_y_range)
        {
            transform.position = new Vector3(transform.position.x, max_y_range, 0);
        }
    }

    //Habilita o triple shot
    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    //O triple shot estara disponivel por Xs
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShot = false;
    }

    //habilita o speedBoost
    public void SpeedBoostPowerUpOn()
    {
        _moreSpeed = 1.7f;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    //Volta a velocidade normal depois de Xs
    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(8.0f);
        _moreSpeed = 1.0f;
    }

    public void Damage()
    {
        if(_shieldEnabled)
        {
            _shieldEnabled = false;
            //desabilita o gameObject
            _shieldGameObject.SetActive(false);
            return;
        }

        //Ativando animacao de dano
        int sideFail = Random.Range(1,3);
        int engineFail = 0;
        //Randomizando os danos(direito ou esquerdo, dano em cima ou em baixo)
        if((sideFail == 1 && _leftEngineFail == false) || _rightEngineFail == true)
        {
            engineFail = Random.Range(0,2);
            _engines[engineFail].SetActive(true);
            _leftEngineFail = true;

        }
        else
        {
            engineFail = Random.Range(2,4);
            _engines[engineFail].SetActive(true);
            _rightEngineFail = true;
        }

        if(_firstDamage == -1)
        {
            _firstDamage = engineFail;
        }
        else
        {
            _secondDamage = engineFail;
        }
        

        _life--;
        _uiManager.UpdateLives(_life);
        //PlayerSpawn();
        
        if(_life < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            _uiManager.ShowTitleScreen();
            Destroy(this.gameObject);
        }
        
    }

    public void ShieldPowerUpOn()
    {
        _shieldEnabled = true;
        //habilitar o gameObject
        _shieldGameObject.SetActive(true);
    }

    public void RemoveDamage()
    {
        //Removendo a animacao de dano
        if(_secondDamage != -1)
        {
            _engines[_secondDamage].SetActive(false);

            //Verificando qual lado que foi consertado
            if(_secondDamage <= 1)
            {
                _leftEngineFail = false;
            }
            else
            {
                _rightEngineFail = false;
            }
            _secondDamage = -1;

        }
        else if(_firstDamage !=  -1)
        {
            _engines[_firstDamage].SetActive(false);
            if(_firstDamage <= 1)
            {
                _leftEngineFail = false;
            }
            else
            {
                _rightEngineFail = false;
            }
            _firstDamage = -1;
        }

        _life++;
        _uiManager.UpdateLives(_life);

        /*
        if(_life < 3)
        {
            _life++;
            _uiManager.UpdateLives(_life);
        }
        */
        
    }

    public int GetLifes()
    {
        return _life;
    }
}
