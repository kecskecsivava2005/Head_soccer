using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public SpriteRenderer player1Renderer;
    public SpriteRenderer player2Renderer;
    public Sprite[] characters;

    private int player1Index = 0;
    private int player2Index = 0;

    void Start()
    {
        

        player1Index = PlayerPrefs.GetInt("Player1Character", 0);
        player2Index = PlayerPrefs.GetInt("Player2Character", 0);
        UpdateCharacters();
    }

    public void NextCharacter(int player)
    {
        if (characters.Length == 0) return;
        Debug.Log("K�vetkez� karakter...");
        if (player == 1)
        {
            player1Index = (player1Index + 2) % characters.Length;
            Debug.Log($"Karakter index: {player1Index} / {characters.Length}");
        }
        else if (player == 2)
        {
            player2Index = (player2Index + 2) % characters.Length;
            Debug.Log($"Karakter index: {player2Index}");
        }
        UpdateCharacters();
    }

    public void PrevCharacter(int player)
    {
        if (characters.Length == 0) return;

        if (player == 1)
        {
            player1Index = (player1Index - 2 + characters.Length) % characters.Length;
        }
        else if (player == 2)
        {
            player2Index = (player2Index - 2 + characters.Length) % characters.Length;
        }
        UpdateCharacters();
    }

    void UpdateCharacters()
    {
        player1Renderer.sprite = characters[player1Index];
        player2Renderer.sprite = characters[player2Index];
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("Player1Character", player1Index);
        PlayerPrefs.SetInt("Player2Character", player2Index);
        PlayerPrefs.Save();
        SceneManager.LoadScene("SampleScene");
    }
}
