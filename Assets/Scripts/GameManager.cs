using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;
    //public GameObject player;
    //private UIManager _uiManager;
    //if game over is true
    //if space key pressed
    //spawn the player
    //gameOver is false
    //hide title screen

    private void Start()
    {
        //_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    void Update()
    {
        /*
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //==Vector3(0,0,0)
                Instantiate(player, Vector3.zero, Quaternion.identity);
                gameOver = false;
                _uiManager.HideTitleScreen();
                _uiManager.score = 0;
            }
        }
        */
    }
    
}