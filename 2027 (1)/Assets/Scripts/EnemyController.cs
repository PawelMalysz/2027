using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    public float speed;
    public bool isHitting;
    public GameObject Hitbox;
    public float hp = 100.0f;
    private float currentAngle = 0f;
    private float latestAngle;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * speed;
        var y = Input.GetAxis("Vertical") * speed;

        transform.position += (new Vector3(x, y, 0));
    }

    void OnColliderEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Hitbox"))
        {
            hp -= 10;
        }
        if (hp <= 0)
            GameObject.Destroy(this);
    }
}
