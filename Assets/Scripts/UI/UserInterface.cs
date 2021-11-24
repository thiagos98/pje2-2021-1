using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    [SerializeField] private GameObject[] screens;
    [SerializeField] private Text levelText;
    private Dictionary<string, GameObject> gameScreens = new Dictionary<string, GameObject>();

    private int level = 0;
    private int currentLevel;
    private BolinhaFisica ball;
    [SerializeField] private Button startButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button nextButton;


    public static UserInterface Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (GameObject go in screens)
        {
            go.SetActive(false);
            gameScreens.Add(go.name, go);
        }

        startButton.onClick.AddListener(StartGame);

        playButton.onClick.AddListener(() => PauseGame(false));
        pauseButton.onClick.AddListener(() => PauseGame(true));
        ShowScreen("MainScreen");
    }

    private void StartGame()
    {
        ball = FindObjectOfType<BolinhaFisica>();
        ball.CanMove = true;

        currentLevel = level + 1;

        levelText.text = "LEVEL " + currentLevel;
        ShowScreen("HUD");
    }

    private void PauseGame(bool pause)
    {
        string screen = pause ? "Pause" : "HUD";
        ShowScreen(screen);
        Time.timeScale = pause ? 0f : 1f;
    }

    private void ShowScreen(string screen)
    {
        DisableScreens();
        gameScreens[screen].SetActive(true);
    }

    private void DisableScreens()
    {
        foreach (GameObject go in gameScreens.Values)
        {
            go.SetActive(false);
        }
    }

    public void Victory()
    {
        ShowScreen("Win");
        level += 1;
    }

    public void ReplayLevel()
    {
        DisableScreens();

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        StartGame();
    }

    public void NextLevel()
    {
        DisableScreens();


        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}