using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    void Start()
    {
        
    }

    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");
        
        float xSpeed = xinput * Speed * Time.deltaTime;
        float ySpeed = yinput * Speed * Time.deltaTime;

        Vector3 move = new Vector3(xSpeed, ySpeed, 0f);
        transform.position += move;

        float clampedX = Mathf.Clamp(transform.position.x, -2.9f, 2.9f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(clampedX, clampedY, 0f);
    }
}
