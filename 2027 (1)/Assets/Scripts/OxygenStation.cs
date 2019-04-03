using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenStation : MonoBehaviour {

    public SphereCollider col;
    private bool isIn = false;
    public int oxygenContainers= 20;
    public GameObject text;
    public PlayerControler pc;
    public AudioSource audioSource;
    public AudioClip clip;
    private GameMaster gm;



	void Start () {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        pc = FindObjectOfType<PlayerControler>();
        col = GetComponent<SphereCollider>();
        audioSource = GetComponent<AudioSource>();
        text.SetActive(false);
	}
    
    void Update()
    {
        if(isIn && Input.GetKeyDown(KeyCode.E))
        {
            if (pc.curOxygen < 80)
            {
                if (oxygenContainers > 0)
                {
                    oxygenContainers--;
                    pc.refillOxygen();
                    gm.ShowMessage("Oxygen refilled");
                    audioSource.PlayOneShot(clip);
                }
                else
                    gm.ShowMessage("There is no more oxygen!");
            }
            else
                gm.ShowMessage("Nothing to refill...");
        }
        
    }
	

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player"))
        {
            isIn = true;
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if(c.CompareTag("Player"))
        {
            isIn = false;
            text.SetActive(false);
        }
    }
}
