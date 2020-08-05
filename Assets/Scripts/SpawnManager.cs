using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab = null;

    //Criando um array de GameObjects
    [SerializeField]
    private GameObject[] _powerUps;

    [SerializeField]
    private float _timeSpawnEnemy = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(true)
        {
            //Enemy contem uma funcao de spawn aleatoria
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeSpawnEnemy);
        }
    }


}
