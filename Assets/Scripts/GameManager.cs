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
    public Text bestText;
    public float distance;
    public static float lastDistance;
    private bool isDead = false;

    public Background background;

    public AudioSource Music;
    public float audioFadeDuration = 1f;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        int best = PlayerPrefs.GetInt("BestDistance", 0);
        bestText.text = "BEST: " + best + "M";
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

        StartCoroutine(FadeOutMusicAndLoad("GameOverScene"));
    }

    private IEnumerator FadeOutMusicAndLoad(string sceneName)
    {
        if (Music == null)
        {
            SceneManager.LoadScene(sceneName);
            yield break;
        }

        float startVol = Music.volume;
        float elapsed = 0f;

        while (elapsed < audioFadeDuration)
        {
            Music.volume = Mathf.Lerp(startVol, 0f, elapsed / audioFadeDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Music.volume = 0f;

        SceneManager.LoadScene(sceneName);
    }
}
