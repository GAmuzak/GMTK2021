using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static UnityAction PlayMenuMusic;
    public static UnityAction PlayGameMusic;

    private void OnEnable()
    {
        PlayMenuMusic?.Invoke();
    }

    public void PlayGame(string level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
        PlayGameMusic?.Invoke();
    }

    private void OnDisable()
    {
        PlayGameMusic?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetTimeScale()
    {
        if (Math.Abs(Time.timeScale) < 1f)
        {
            Time.timeScale = 1f;
        }
    }
}
