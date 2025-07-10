using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    public float resetY;     
    public Transform[] Backgrounds;  

    void Update()
    {
        foreach (Transform bg in Backgrounds)
        {
            bg.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

            if (bg.position.y <= -resetY)
            {
                float topY = GetTopBackgroundY();
                bg.position = new Vector3(bg.position.x, topY + resetY, bg.position.z);
            }
        }
    }

    float GetTopBackgroundY()
    {
        float topY = Backgrounds[0].position.y;
        foreach (Transform bg in Backgrounds)
        {
            if (bg.position.y > topY)
                topY = bg.position.y;
        }
        return topY;
    }
}
