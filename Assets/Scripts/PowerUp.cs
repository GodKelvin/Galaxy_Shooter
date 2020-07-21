using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //movimentando para fora da cena 3m/s
    [SerializeField]
    private float _speed = 3.0f;
   
    // Update is called once per frame
    void Update()
    {
        //Fazendo-o cair em tempo real 3m/s
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OPA: " + other.name);
    }
}
