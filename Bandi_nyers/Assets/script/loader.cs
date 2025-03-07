using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class loader : MonoBehaviour
{
    public SpriteRenderer player1Renderer;
    public SpriteRenderer player2Renderer;
    public Sprite[] characters; 
    void Start()
    {

        // Bet�ltj�k a karakterek indexeit
        int player1Index = PlayerPrefs.GetInt("Player1Character", 0);
        int player2Index = PlayerPrefs.GetInt("Player2Character", 0);

        // Ellen�rizz�k, hogy van-e el�rhet� karakter
        if (characters.Length > 0)
        {
            player1Renderer.sprite = characters[player1Index];
            player2Renderer.sprite = characters[player2Index];
        }
        else
        {
            Debug.LogError("A characters t�mb nincs be�ll�tva a CharacterLoader scriptben!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
