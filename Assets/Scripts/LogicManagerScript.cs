using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject playerScoresPanel;
    public Text playerScoreObject;
    public Text gameOverText;
    protected int gameScore = 0;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        playerScoresPanel.SetActive(false);
        SetGameOverText("Game Over - Score: " + gameScore);
    }

    public void SetGameOverText(string text)
    {
        gameOverText.text = text;
    }

    public void AddScore(int score)
    {
        gameScore += score;
        playerScoreObject.text = gameScore.ToString();
    }
}
