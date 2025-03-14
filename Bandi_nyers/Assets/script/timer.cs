using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float remainingTime = 180f;
    private bool isRunning = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            timeText.text = FormatTime(remainingTime);
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        isRunning = true;
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1f);
            remainingTime--;
            timeText.text = FormatTime(remainingTime);
        }

        isRunning = false;
        Stopped();
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    void Stopped()
    {
        Debug.Log("Idő lejárt!");
        timeText.text = "Az idő lejárt!";
    }
}
