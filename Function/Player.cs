using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public SpriteRenderer sR;
    private Rigidbody2D rb;
    public float jumpHeight;
    public string currentColor;

    public float score;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        RandomColor();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
            scoreText.text = "" + score;
        }
    }

    private void RandomColor()
    {
        int i = Random.Range(0, 4);

        switch (i)
        {
            case 0:
                currentColor = "Cyan";
                sR.color = new Color(54f / 255f, 225f / 255f, 243f / 255f);
                break;
            case 1:
                currentColor = "Green";
                sR.color = new Color(69f / 255f, 221f / 255f, 0f);
                break;
            case 2:
                currentColor = "Pink";
                sR.color = new Color(248f / 255f, 2f / 255f, 129f / 255f);
                break;
            case 3:
                currentColor = "Brown";
                sR.color = new Color(75f / 255f, 0f, 0f);
                break;
        }
    }
    private void jump()
    {
        rb.velocity = Vector2.up * jumpHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jump();
        }

        if (collision.gameObject.tag == "changeColor")
        {
            RandomColor();
        }

        if (collision.gameObject.tag == "Star")
        {
            score += 1;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object's tag is not the current color
        if (collision.gameObject.tag != currentColor)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.tag == "Finish")
        {
            // Check if the current level is level 7
            if (SceneManager.GetActiveScene().name == "Level 7")
            {
                // Display game over screen instead of loading a new level
                // You need to replace "GameOverScene" with the name of your actual game over scene
                SceneManager.LoadScene("GameOverScene");
            }
            else
            {
                // Load the next level based on the current level's build index
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }

    }
}