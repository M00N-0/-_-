using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public static float xLimit = 2.9f;
    public static float yLimit = 4.5f;
    
    public AudioClip explosionSound;

    private Animator animator;
    private AudioSource audioSource;

    private bool isDead = false;
    private bool isInvincible = false;

    public GameObject invincibleEffectPrefab;
    private GameObject invEffectInstance;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isDead) return;
        float xinput = Input.GetAxis("Horizontal");
        float yinput = Input.GetAxis("Vertical");

        float xSpeed = xinput * Speed * Time.deltaTime;
        float ySpeed = yinput * Speed * Time.deltaTime;

        Vector3 move = new Vector3(xSpeed, ySpeed, 0f);
        transform.position += move;

        float clampedX = Mathf.Clamp(transform.position.x, -xLimit, xLimit);
        float clampedY = Mathf.Clamp(transform.position.y, -yLimit, yLimit);
        transform.position = new Vector3(clampedX, clampedY, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead || isInvincible) return;
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        isDead = true;

        animator.SetBool("isDead", true);

        audioSource.PlayOneShot(explosionSound);

        var col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        yield return null;

        var info = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(info.length);
    
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }

    public void ActivateInvincibility(float duration)
    {
        if (!isInvincible)
            StartCoroutine(InvincibleCoroutine(duration));
    }

    private IEnumerator InvincibleCoroutine(float duration)
    {
        isInvincible = true;

        if (invincibleEffectPrefab != null)
        {
            invEffectInstance = Instantiate(invincibleEffectPrefab, transform);
            invEffectInstance.transform.localPosition = Vector3.zero;
        }

        yield return new WaitForSeconds(duration);

        if (invEffectInstance != null)
            Destroy(invEffectInstance);

        isInvincible = false;
    }
}