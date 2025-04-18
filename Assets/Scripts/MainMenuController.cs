using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public CanvasGroup OptionPanel;
    public AudioClip buttonSound; // Reference to the sound file // Reference to the AudioSource component

    public void PlayGame()
    {
        // Play sound when button is clicked
        if (buttonSound != null)
        {
            AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
        }
        
        // Wait a brief moment to let the sound play before changing scene
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        // Wait for a short duration to let the sound play
        yield return new WaitForSeconds(0.1f);
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
