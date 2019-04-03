using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;
    public float smoothSpeed;

	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
	void Update () {
        Vector3 desirePosition = target.position + new Vector3(0,0,-10);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        transform.position = smoothPosition;
        
	}
}
