using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkryptMenu : MonoBehaviour {

    public Canvas menuWyjscia;
    public Button playBtn;
    public Button exitBtn;
    public AudioSource audioSource;
   
	void Start () {
        menuWyjscia = menuWyjscia.GetComponent<Canvas>();
        playBtn = playBtn.GetComponent<Button>();
        exitBtn = exitBtn.GetComponent<Button>();
        menuWyjscia.enabled = false;
	}

    public void ExitButtonOn ()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        menuWyjscia.enabled = true;
        playBtn.enabled = false;
        exitBtn.enabled = false;
    }
	
    public void ExitButtonOff()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        menuWyjscia.enabled = false;
        playBtn.enabled = true;
        exitBtn.enabled = true;
    }

    public void PoziomStartowy ()
    {
        SceneManager.LoadScene("playscene");
        FindObjectOfType<AudioManager>().Play("Accept");
        PlayerPrefs.SetInt("koniec", 0);
    }

    public void EndGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
