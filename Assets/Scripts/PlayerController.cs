using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // variables
    public Rigidbody rb;
    public float speed = 2000;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseImg;
    public GameObject WinLose;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
            rb.AddForce(0, 0, speed * Time.deltaTime);
        if (Input.GetKey("s") || Input.GetKey("down"))
            rb.AddForce(0, 0, -1 * speed * Time.deltaTime);
        if (Input.GetKey("a") || Input.GetKey("left"))
        rb.AddForce(-1 * speed * Time.deltaTime, 0, 0);
        if (Input.GetKey("d") || Input.GetKey("right"))
        rb.AddForce(speed * Time.deltaTime, 0, 0);

        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }

    // Detects collision between player and other gameObjects
    // Checks tags to see if action is neccessary
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            Destroy (other.gameObject);
            SetScoreText();
        }

        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            SetHealthText();
            if (health == 0)
            {
                SetLoseText();
                StartCoroutine(LoadScene(3));
            }
        }

        if (other.gameObject.tag == "Goal")
        {
            SetWinText();
            StartCoroutine(LoadScene(3));
        }
    }

    // Sets players score by updating UI Text element.
    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    // Sets players health by updating UI Text element.
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }

    // Sets image & text color to win scenario
    void SetWinText()
    {
        WinLoseText.text = "You Win!";
        WinLoseText.color = new Color(0, 0, 0);
        WinLoseImg.color = new Color(0, 255, 0);
        WinLose.SetActive(true);
    }

    // Sets image & text color to lose scenario
    void SetLoseText()
    {
        WinLoseText.text = "Game Over!";
        WinLoseText.color = new Color(255, 255, 255);
        WinLoseImg.color = new Color(255, 0, 0);
        WinLose.SetActive(true);
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Maze");
    }

}
