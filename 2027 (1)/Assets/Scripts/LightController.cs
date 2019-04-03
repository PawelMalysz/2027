using UnityEngine;

public class LightController : MonoBehaviour {

    private Light l;
    public float duration = 30f; // 30f == 1 day is 1 minute
    public float t;
    public int day=0;

	void Start () {
        l = GetComponent<Light>();
	}

	void Update () {
        t = Mathf.PingPong(Time.time, duration)/duration;
       print("czas "+t);
        l.color = Color.Lerp(Color.white, Color.black, t);
        
	}
}
