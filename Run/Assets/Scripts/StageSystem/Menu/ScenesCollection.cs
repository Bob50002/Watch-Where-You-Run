using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesCollection : MonoBehaviour
{
    [Header("Menu scene name here")]
    [SerializeField] string MainMenu;

    [Header("First tutorial scene name here")]
    [SerializeField] string FirstPage;

    [Header("Second tutorial scene name here")]
    [SerializeField] string SecondPage;

    [Header("Credits scene name here")]
    [SerializeField] string Credits;

    [Header("Settings scene name here")]
    [SerializeField] string Settings;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToCredit()
    {
        SceneManager.LoadScene(Credits);
    }

    public void ToSettings()
    {
        SceneManager.LoadScene(Settings);
    }

    public void ToFirstTutorialPage()
    {
        SceneManager.LoadScene(FirstPage);
    }

    public void ToSecondTutorialPage()
    {
        SceneManager.LoadScene(SecondPage);
    }

}