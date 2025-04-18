using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    public int score;
    public int lives = 3; // Player starts with 3 lives
    public bool GameOver;
    public Transform Title;
    public TextMeshProUGUI scoreboard;
    public AudioClip buttonClickSound; // Sound for button clicks
    public GameObject[] heartObjects;
    void Start()
    {
        score = 0;
        lives = 3;
        GameOver = false;
        scoreboard.text = "0";

        if (heartObjects == null || heartObjects.Length == 0)
        {
            heartObjects = new GameObject[3];
            for (int i = 0; i < 3; i++)
            {
                heartObjects[i] = GameObject.Find("heart_" + i);
            }
        }
        UpdateHearts();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == true)
        {
            Title.localPosition = new Vector3(0f, 0f, 0f);
            // Don't set GameOver back to false
        }
    }

    public void ScoreAdd()
    {
        if (!GameOver) // Only add score if game is not over
        {
            score++;
            scoreboard.text = score.ToString();
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateHearts();

        if (lives <= 0)
        {
            GameOver = true;
            lives = 0;
        }
    }

    private void UpdateHearts()
    {
        // Update the visibility of hearts based on remaining lives
        for (int i = 0; i < heartObjects.Length; i++)
        {
            if (heartObjects[i] != null)
            {
                heartObjects[i].SetActive(i < lives);
            }
        }
    }

    public void NewGame()
    {
        PlayButtonSound();
        StartCoroutine(LoadSceneWithDelay(1));
    }

    public void MainMenu()
    {
        PlayButtonSound();
        StartCoroutine(LoadSceneWithDelay(0));
    }

    private void PlayButtonSound()
    {
        if (buttonClickSound != null)
        {
            AudioSource.PlayClipAtPoint(buttonClickSound, Camera.main.transform.position);
        }
    }

    private IEnumerator LoadSceneWithDelay(int sceneIndex)
    {
        // Wait a brief moment to let the sound play
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
