using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultMenu : MonoBehaviour
{
    public static ResultMenu instance;

    public GameObject result;
    public GameObject gameState;

    private Animator anim;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("Seconds"))
            result.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Seconds").ToString();
        if (PlayerPrefs.HasKey("GameState"))
        {
            switch (PlayerPrefs.GetString("GameState"))
            {
                case "Win":
                    {
                        gameState.GetComponent<TextMeshProUGUI>().text = "Вы выиграли!";
                        anim.SetTrigger("startWin");
                        break;
                    }
                case "Lose":
                    {
                        gameState.GetComponent<TextMeshProUGUI>().text = "Вы проиграли!";
                        anim.SetTrigger("startLose");
                        break;
                    }
                default:
                    {
                        anim.SetTrigger("start");
                        break;
                    }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            BackToMenu();
    }

    public void BackToMenu()
    {
        anim.SetTrigger("backToMain");   
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
