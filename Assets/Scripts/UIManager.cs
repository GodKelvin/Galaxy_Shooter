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

    private int _scoreForLife = 500;
    private int _scoreUntilLife = 0;

    private Player _player = null;

    [SerializeField]
    private AudioClip _clipSoundGainLife = null;

    [SerializeField]
    private AudioClip _clipSoundGainPoints = null;

    private int _scoreBonus = 200;

    public GameObject player;
    private GameManager _gameManager;

    public GameObject optionsPanel;
    public GameObject howToPlayPanel;

    private VolumeOptions _optionsManager;
    private float _volumeEffect = 1f;

    void Start()
    {
        _optionsManager = GameObject.Find("OptionsManager").GetComponent<VolumeOptions>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    public void UpdateLives(int currentPlayerLives)
    {
        //Debug.Log("Player lives: " + currentPlayerLives);
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

            //Altero a velocidade de todos os inimigos diretamente no Script EnemyAI(pela variavel ser static)
            EnemyAI._speed += 1;

            if(_player)
            {
                _volumeEffect = _optionsManager.GetEffectVolume();
                if(_player.GetLifes() < 3)
                {
                    //O que vai tocar, posicao na tela, volume
                    AudioSource.PlayClipAtPoint(_clipSoundGainLife, Camera.main.transform.position, _volumeEffect);
                    _player.RemoveDamage();
                }
                else
                {
                    score += _scoreBonus;
                    scoreText.text = "SCORE: " + score;
                    //O que vai tocar, posicao na tela, volume
                    AudioSource.PlayClipAtPoint(_clipSoundGainPoints, Camera.main.transform.position, _volumeEffect);
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

    public void QuitGame()
    {
        //Editor Unity
        //UnityEditor.EditorApplication.isPlaying = false;
       
    
        //Jogo compilado
        Application.Quit();
        
    }

    public void StartGame()
    {
        Instantiate(player, Vector3.zero, Quaternion.identity);
        HideTitleScreen();
        _gameManager.gameOver = false;
        score = 0;
        _scoreUntilLife = 0;
        EnemyAI._speed = 4.5f;
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }
    
    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }
}