using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    [Header("Audio")]
    public AudioSource bgMusic;

    private bool gameStarted = false;
    private bool gameEnded = false;

    void Start()
    {
        Time.timeScale = 0f;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }

    public void PlayGame()
    {
        gameStarted = true;
        gameEnded = false;
        Time.timeScale = 1f;

        startPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);

        if (bgMusic != null && !bgMusic.isPlaying)
            bgMusic.Play();
    }

    public void GameOver()
    {
        if (gameEnded) return;

        gameEnded = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        if (bgMusic != null) bgMusic.Stop();
    }

    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;
        Time.timeScale = 0f;
        winPanel.SetActive(true);

        if (bgMusic != null) bgMusic.Stop();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
