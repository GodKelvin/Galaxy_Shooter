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

    [SerializeField]
    private AudioClip _clipSoundGainLife = null;

    [SerializeField]
    private AudioClip _clipSoundGainPoints = null;

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

            //Altero a velocidade de todos os inimigos (pela variavel ser static)
            EnemyAI._speed += 1;

            if(_player)
            {
                if(_player.GetLifes() < 3)
                {
                    AudioSource.PlayClipAtPoint(_clipSoundGainLife, Camera.main.transform.position, 1f);
                    _player.RemoveDamage();
                }
                else
                {
                    score += 50;
                    scoreText.text = "SCORE: " + score;
                    AudioSource.PlayClipAtPoint(_clipSoundGainPoints, Camera.main.transform.position, 1f);
                }
               
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
