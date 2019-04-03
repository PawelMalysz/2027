using UnityEngine;

public class Clock : MonoBehaviour {

    private float t;
    public GameObject light;
    private LightController lightController;


    void Start()
    {
        light = GameObject.FindGameObjectWithTag("Light");
        lightController = light.GetComponent<LightController>();
    }
    
    
	void Update ()
    {      
        t = Time.time * (lightController.duration/5);
        transform.rotation = Quaternion.Euler(0, 0, -t);
	}
}
