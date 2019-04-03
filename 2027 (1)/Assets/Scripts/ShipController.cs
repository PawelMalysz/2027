using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {

    public float shipHP;
    public Text buildProgress;
    public Image buildBar;
    public int playerPickups;
    public int playerEngines;
    public Text pickupsText;

    private float maxShpHP =100f;

    static GameObject player;
    PlayerControler playerControler;

    void Start () {
        player = GameObject.FindWithTag("Player");
        playerControler = player.GetComponent<PlayerControler>();
        playerPickups = playerControler.pickedUP;
        playerEngines = playerControler.engines;
    }
	
	void Update () {

        playerPickups = playerControler.pickedUP;
        playerEngines = playerControler.engines;

        playerControler.picked.text = "" + playerPickups;
        playerControler.pEngines.text = "" + playerEngines;

        Build();

        if (shipHP >= 100)
        {
            SceneManager.LoadScene("winscene", LoadSceneMode.Single);
        }
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            if (shipHP <100 && playerPickups >0)
            {
                shipHP += 2;
                playerControler.pickedUP--;
            }

            else if(shipHP <100 && playerEngines > 0)
            {
                shipHP += 10;
                playerControler.engines--;
            }
        }

    }

    void Build()
    {
        buildBar.fillAmount = shipHP / maxShpHP;
    }
}
