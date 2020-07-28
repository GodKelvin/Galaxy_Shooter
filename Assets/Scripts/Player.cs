using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Mesmo com  atributo privado, mostra-lo no inspector
    [SerializeField]
    private float _speed = 5.0f;

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
    private float _moreSpeed = 1.0f;

    [SerializeField]
    private int _life = 3;


    // Start is called before the first frame update
    void Start()
    {
        PlayerSpawn();
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
        _moreSpeed = 2.5f;
        StartCoroutine(SpeedBoostDownRoutine());
    }

    //Volta a velocidade normal depois de Xs
    public IEnumerator SpeedBoostDownRoutine()
    {
        yield return new WaitForSeconds(8.0f);
        _moreSpeed = 1.0f;
    }

    /*
    public int GetLife()
    {
        return _life;
    }

    public void LoseOneLife()
    {
        _life -= 1;
    }
    */
    public void Damage()
    {
        _life--;
        //PlayerSpawn();
        
        if(_life < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
