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
        SceneManager.LoadScene(jatek, LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

}
