using System;
using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3.3f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Animator bobAnimator;
    [SerializeField] private SpriteRenderer spriteRenderer;



    private float score = 0;
    private bool flip = false;

    void Start()
    {
        Debug.Log("Speed:" + speed);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime);
        bobAnimator.SetFloat("Speed", horizontal * speed);
        Debug.Log("No, I am on github");

        if (horizontal < 0)
        {
            flip = true;
        }
        else
        {
            flip = false;
        }
        spriteRenderer.flipX = flip;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            score = score + 1;

            scoreText.text = "Score: " + score;
            other.GetComponent<AudioSource>().Play();
        }
    }
}