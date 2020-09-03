using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.5f;

    //public Animator anim;
    [SerializeField]
    private GameObject _enemyExplosionPrefab = null;

    private UIManager _uiManager;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //Encontrando o objeto do canvas para manipularmos
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
         _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        EnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        if(_gameManager.gameOver)
        {
             Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            _enemyExplosionPrefab.transform.Translate(Vector3.down * Time.deltaTime * _speed);
            Destroy(this.gameObject);
        }
    }

    private void EnemySpawn()
    {
        float yPosition = 8.65f;
        float xPosition = Random.Range(-7.44f, 7.59f);
        transform.position = new Vector3(xPosition, yPosition, 0);
    }

    private void EnemyMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -6.53f)
        {
            //Quando o inimigo sai da tela sem ser destruido, utilizo o mesmo Object pro respawn
            EnemySpawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //Instanciando a explosao no mesmo lugar que o inimigo foi atingido, na rotacao padrao (Quaternion)
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            _enemyExplosionPrefab.transform.Translate(Vector3.down * Time.deltaTime * _speed);
            _uiManager.UpdateScore();
            Destroy(this.gameObject);
            
            
        }
        else if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                /*
                if(player.GetLife() > 0)
                {
                    player.LoseOneLife();
                    player.PlayerSpawn();
                }
                else
                {
                    Destroy(other.gameObject);
                }
                */
                player.Damage();
                
            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        //Independente da colisao,  sou destruido
        //Destroy(this.gameObject);
    }
}
