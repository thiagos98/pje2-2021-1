using System;
using UnityEngine;
using UnityEngine.UI;
public class UserInterface : MonoBehaviour
{
    private bool started;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private BolinhaFisica ball;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        /*
         if (!started && Input.anyKey)
        {
            StartGame();
        }
        */
    }

    public void StartGame()
    {
        started = true;
        ball.CanMove = true;
        mainScreen.SetActive(false);
    }
}