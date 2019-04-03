using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {
    
    public float speed;
    public bool isHitting;
    public GameObject Hitbox;
    public Image oxygenBar;
    public Text picked;
    public Text pEngines;
    public AudioClip walkSound;

    public GameObject gameOverUI;

    public Rigidbody rb;
    public AudioSource audio;
    public AudioSource audio2;

    public int pickedUP;
    public int engines;

    private float currentAngle = 0f;
    private float latestAngleY;
    private float latestAngleZ;
    public float curOxygen;
    private bool isMoving;
    private bool barChanged;
    private Color defaultBarColor;

    public float startOxygen= 100;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Hitbox = GameObject.FindGameObjectWithTag("Hitbox");
        latestAngleY = Hitbox.transform.eulerAngles.y;
        latestAngleZ = Hitbox.transform.eulerAngles.z;
        rb = GetComponent<Rigidbody>();
        curOxygen = startOxygen;


        pickedUP = 0;
        engines = 0;

        InvokeRepeating("Oxygen", 0.01f, 1f);
        InvokeRepeating("PlaySound", 1f, 0.36f);
        defaultBarColor = oxygenBar.color;

        gameOverUI.SetActive(false);
    }
    
	void Update () {

        var x = Input.GetAxis("Horizontal") * speed;
        var y = Input.GetAxis("Vertical") * speed;

        transform.position += (new Vector3(x, y, 0));
        
        if (curOxygen <= 40 && !barChanged)
        {
            FindObjectOfType<AudioManager>().Play("LowOxygen");
            oxygenBar.color = new Color(255, 0, 0);
            barChanged = true;
            audio2.Pause();
        }
        else if(curOxygen>40 && barChanged)
        {
            FindObjectOfType<AudioManager>().StopMusic("LowOxygen");
            oxygenBar.color = defaultBarColor;
            barChanged = false;
            audio2.UnPause();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Hitbox.SetActive(true);
            isHitting = true;
        }
        if(isHitting)
        {
            currentAngle += 480f * Time.deltaTime;

            // Hitbox.transform.rotation = Quaternion.Euler(0, latestAngleY - currentAngle, latestAngleZ - currentAngle);
            Hitbox.transform.rotation = Quaternion.Euler(0, latestAngleY, latestAngleZ) * Quaternion.Euler(0,-currentAngle,-currentAngle);

            if (currentAngle > 120f)
            {
                isHitting = false;
                currentAngle = 0f;
            } 
        }
        else
        {
            latestAngleY = Hitbox.transform.eulerAngles.y;
            latestAngleZ = Hitbox.transform.eulerAngles.z;
            Hitbox.SetActive(false);
        }

        if (curOxygen <= 0)
        {
            PlayerPrefs.SetInt("koniec", 1);
            gameOverUI.SetActive(true);
        }
    }    

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            FindObjectOfType<AudioManager>().Play("Picked");
            Destroy(other.gameObject);
            pickedUP++;
        }

        else if (other.gameObject.CompareTag("Engine"))
        {
            FindObjectOfType<AudioManager>().Play("Picked");
            Destroy(other.gameObject);
            engines++;

        }
    }

    public void TakeDmg(float value, Vector3 vector)
    {
        curOxygen -= value;
        rb.velocity = -vector;
        //rb.AddForce(-vector, ForceMode.Impulse);
    }

    void Oxygen()
    {
        curOxygen -= 1;
        oxygenBar.fillAmount = curOxygen / startOxygen;
    }

    void PlaySound()
    {
        if(Input.GetButton("Vertical")|| Input.GetButton("Horizontal"))
        {
            audio.pitch = Random.Range(0.7f, 1.5f);
            audio.PlayOneShot(walkSound);
        }
    }

    public void refillOxygen()
    {
        curOxygen = startOxygen;
    }


    private void GameOver()
    {
        if (curOxygen <= 0)
        {
            Time.timeScale = 0.0f;

            gameOverUI.SetActive(true);
            audio.Pause();

        }
    }
}
