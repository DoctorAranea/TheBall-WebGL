using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowResultScreen()
    {
        anim.SetTrigger("checkResult");
    }

    public void BackToMain()
    {
        anim.SetTrigger("backToMain");
    }

    public void PlayTheGame()
    {
        anim.SetTrigger("play");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadResults()
    {
        PlayerPrefs.SetString("GameState", "");
        SceneManager.LoadScene(2);
    }
}
