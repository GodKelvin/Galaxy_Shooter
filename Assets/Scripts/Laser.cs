using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Posicao do objeto associado ao script
        //Movendo-o para cima numa velocidade X * o tempo
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //Quando o laser sai de cena, destruimos o objeto
        if(transform.position.y >= 6)
        {
            //Destroy(this.gameObject)
            Destroy(gameObject);
        }
    }
}
