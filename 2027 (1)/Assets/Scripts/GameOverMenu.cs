using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public AudioSource audio;

    public void Update()
    {
        if(PlayerPrefs.GetInt("koniec")==1)
        {
            audio.Stop();
            Time.timeScale = 0.0f;
        }
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("menuscene", LoadSceneMode.Single);
    }

    public void Zakonczenie()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
