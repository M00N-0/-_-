using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text distanceText;
    public float distance;
    public static float lastDistance;
    private bool isDead = false;

    public Background background;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }
    void Update()
    {
        if (isDead) return;
        distance += Time.deltaTime * background.scrollSpeed; 
        distanceText.text = Mathf.FloorToInt(distance) + "M";
    }


    public void GameOver()
    {
        isDead = true;

        lastDistance = distance;

        int best = PlayerPrefs.GetInt("BestDistance", 0);
        int current = Mathf.FloorToInt(distance);
        if (current > best)
        {
            PlayerPrefs.SetInt("BestDistance", current);
            PlayerPrefs.Save();
        }

        SceneManager.LoadScene("GameOverScene");
    }
}
