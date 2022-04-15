using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    private Transform player;
    private Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
        if (player.position.y <= -4)
            GameOver();
    }

    public void WinGame()
    {
        PlayerPrefs.SetString("GameState", "Win");
        anim.SetTrigger("theEnd");
    }

    public void GameOver()
    {
        PlayerPrefs.SetString("GameState", "Lose");
        anim.SetTrigger("theEnd");
    }

    public void ToResult()
    {
        SceneManager.LoadScene(2);
    }
}
