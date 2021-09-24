using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace General
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject panelGameOver;

        private void Start()
        {
            SetPanelGameOver(false, 1f);
        }

        public void SetPanelGameOver(bool value, float time)
        {
            Time.timeScale = time;
            panelGameOver.SetActive(value);
        }

        public static void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
