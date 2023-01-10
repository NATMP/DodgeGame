using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    public GameObject lostMenu;
    public void SetActive()
    {
        lostMenu.SetActive(true);
        Pause();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.score = 0;
        Resume();
    }
}
