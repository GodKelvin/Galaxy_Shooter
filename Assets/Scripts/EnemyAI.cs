using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
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
            Destroy(this.gameObject);
            Destroy(other.gameObject);
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
            Destroy(this.gameObject);
        }
        //Independente da colisao,  sou destruido
        //Destroy(this.gameObject);
    }
}
