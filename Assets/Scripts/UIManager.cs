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

    public void UpdateLives(int currentPlayerLives)
    {
        Debug.Log("Player lives: " + currentPlayerLives);
        livesImageDisplay.sprite = livesSpritesArray[currentPlayerLives];
    }

    public void UpdateScore()
    {

    }
}
