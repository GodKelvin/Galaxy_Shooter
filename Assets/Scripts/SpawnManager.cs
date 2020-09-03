using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab = null;

    //Criando um array de GameObjects
    [SerializeField]
    private GameObject[] _powerUpsVector = null;

    [SerializeField]
    private float _timeSpawnEnemy = 3f;

    [SerializeField]
    private float _timeSpawnPowerUp = 5f;

    //Acessando a variavel gameOver do GameManager
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
        
    }

    //Metodo chamado pelo player quando o jogo eh iniciado
    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }
    IEnumerator EnemySpawnRoutine()
    {
        while(!_gameManager.gameOver)
        {
            //Enemy contem uma funcao de spawn aleatoria
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawnEnemy);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while(!_gameManager.gameOver)
        {
            int selectPowerUp = Random.Range(0,3);
            Instantiate(_powerUpsVector[selectPowerUp], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawnPowerUp);
        }   
    }
}
