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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while(true)
        {
            //Enemy contem uma funcao de spawn aleatoria
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawnEnemy);
        }
    }

    IEnumerator PowerUpSpawnRoutine()
    {
        while(true)
        {
            int selectPowerUp = Random.Range(0,3);
            Instantiate(_powerUpsVector[selectPowerUp], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawnPowerUp);
        }   
    }
}
