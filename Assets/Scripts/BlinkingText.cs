using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private Text pressText;
    [SerializeField] private float fadingInterval;

    private float elapsedTime;
    private bool isFadeIn;

    void Awake()
    {
        if (pressText == null)
            pressText = GetComponent<Text>();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (isFadeIn)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime >= fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0f;
            }
        }
        else
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime >= fadingInterval)
            {
                isFadeIn = true;
                elapsedTime = 0f;
            }
        }
    }

    private void SetTextAlpha(float alpha)
    {
        Color color = pressText.color;
        color.a = alpha;
        pressText.color = color;
    }
}
