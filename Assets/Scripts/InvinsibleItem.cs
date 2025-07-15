using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinsibleItem : MonoBehaviour
{
    public float duration = 2f;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null)
                player.ActivateInvincibility(duration);

            Destroy(gameObject);
        }
    }
}
