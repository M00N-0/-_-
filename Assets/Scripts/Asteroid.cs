using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Vector2 moveDir;
    private float moveSpeed;

    public SpriteRenderer sr;

    void Update()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
            Destroy(gameObject);
    }

    public void Init(Vector2 dir, float speed, Sprite sprite)
    {
        moveDir = dir.normalized;
        moveSpeed = speed;
        sr.sprite = sprite;
    }
}
