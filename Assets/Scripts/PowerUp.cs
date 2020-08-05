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
   
    // Update is called once per frame
    void Update()
    {
        //Fazendo-o cair em tempo real 3m/s
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
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
             Destroy(this.gameObject);
        }
    }
}
