using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Acesso a todos os elementos de UI do editor do unity
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Sprite[] livesSpritesArray = null;

    //Referenciando o sprite de vidas na tela do jogador
    public Image livesImageDisplay = null;
    public int score;

    public Text scoreText;
    public GameObject titleScreen;

    private int _scoreForLife = 100;
    private int _scoreUntilLife = 0;

    private Player _player = null;

    public void UpdateLives(int currentPlayerLives)
    {
        Debug.Log("Player lives: " + currentPlayerLives);
        livesImageDisplay.sprite = livesSpritesArray[currentPlayerLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;
        _scoreUntilLife += 10;

        if(_scoreUntilLife >= _scoreForLife)
        {
            _scoreUntilLife = 0;
            _player = GameObject.Find("Player(Clone)").GetComponent<Player>();
            if(_player)
            {
                _player.RemoveDamage();
            }
        }
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "SCORE: 0";
    }
}
