using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string jatek;

    public void LoadGame()
    {
        SceneManager.LoadScene("CharacterSelector");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
