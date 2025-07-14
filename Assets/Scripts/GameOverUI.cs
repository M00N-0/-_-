using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text currentScoreText;
    public Text bestScoreText;

    void Start()
    {
        int current = Mathf.FloorToInt(GameManager.lastDistance);
        currentScoreText.text = "Current: " + current + "M";

        int best = PlayerPrefs.GetInt("BestDistance", 0);
        bestScoreText.text = "Best: " + best + "M";
    }

    public void OnRestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
