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

    public void UpdateLives(int currentPlayerLives)
    {
        Debug.Log("Player lives: " + currentPlayerLives);
        livesImageDisplay.sprite = livesSpritesArray[currentPlayerLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;
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
