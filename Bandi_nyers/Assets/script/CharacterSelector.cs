using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public SpriteRenderer player1Renderer;
    public SpriteRenderer player2Renderer;
    public Sprite[] characters;

    private static int player1Index = 0;
    private static int player2Index = 1;

    private static CharacterSelector instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        UpdateCharacters();
    }

    public void NextCharacterPlayer1()
    {
        if (player1Index == 0)
        {
            player1Index = 2;
        }
        else
        {
            player1Index = 0;
        }
        UnityEngine.Debug.Log($"Player 1 következő karakter: {player1Index}");
        UpdateCharacters();
    }

    public void NextCharacterPlayer2()
    {
        if (player2Index == 1)
        {
            player2Index = 3;
        }
        else
        {
            player2Index = 1;
        }
        UnityEngine.Debug.Log($"Player 2 következő karakter: {player2Index}");
        UpdateCharacters();
    }

    public void PrevCharacterPlayer1()
    {
        player1Index = (player1Index == 2) ? 0 : 2;
        UnityEngine.Debug.Log($"Player 1 előző karakter: {player1Index}");
        UpdateCharacters();
    }

    public void PrevCharacterPlayer2()
    {
        player2Index = (player2Index == 3) ? 1 : 3;
        UnityEngine.Debug.Log($"Player 2 előző karakter: {player2Index}");
        UpdateCharacters();
    }

    void UpdateCharacters()
    {
        if (player1Renderer != null && player2Renderer != null && characters.Length >= 4)
        {
            player1Renderer.sprite = characters[player1Index];
            player2Renderer.sprite = characters[player2Index];
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static int[] GetIndex()
    {
        return new int[] { player1Index, player2Index };
    }
}
