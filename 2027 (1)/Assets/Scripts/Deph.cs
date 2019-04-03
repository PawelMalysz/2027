using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deph : MonoBehaviour {

    private float x;
    private float y;

    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;

        transform.position = new Vector3(x, y, y);
    }

	void FixedUpdate () {
        x = transform.position.x;
        y = transform.position.y;

        transform.position = new Vector3(x, y, y);

	}
}
