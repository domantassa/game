using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
    }
    public void PlayGame()
    {
        Cursor.visible = false;
        FindObjectOfType<AudioManager>().Play("PlayButton");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
