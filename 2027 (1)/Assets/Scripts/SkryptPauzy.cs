using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkryptPauzy : MonoBehaviour {

    public GameObject PauseUI;
    private bool paused = false;
    public AudioSource audio;
    

	void Start () {
        PauseUI.SetActive(false);
	}
	
	void Update () {

        if (Input.GetKeyDown("escape"))
        {
            FindObjectOfType<AudioManager>().Play("Click");
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0.0f;
            audio.Pause();
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1.0f;
            audio.UnPause();
        }
	}

    public void Wznowienie()
    {
        FindObjectOfType<AudioManager>().Play("Accept");
        paused = false;
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
