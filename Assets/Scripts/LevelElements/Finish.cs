using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static Finish instance;

    private GameObject timer;
    private SceneChanger sceneChanger;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        sceneChanger = GameObject.FindGameObjectWithTag("SceneChanger").GetComponent<SceneChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            timer.GetComponent<Timer>().SaveTime();
            sceneChanger.WinGame();
        }
    }
}
