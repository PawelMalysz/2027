using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    public Animator anim;
    private Quaternion hitbox_direction;
    private GameObject hitbox;
    private GameObject target;
  //  private GameObject enemy;
    public float x;
    public float y;
   

    void Start()
    {
       // enemy = GetComponent<GameObject>();
        anim = GetComponent<Animator>();

      //  enemy = enemy.GetComponent<GameObject>();
        target = GameObject.FindGameObjectWithTag("Player");
        hitbox = GameObject.FindGameObjectWithTag("Hitbox");
    }

    void Update()
    {
        x = (target.transform.position.x - transform.position.x);
        y = (target.transform.position.y - transform.position.y);
       
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);

        if (anim.GetBool("en_Attack") == true)
        {
            anim.SetLayerWeight(1, 1);
        }
        else
            anim.SetLayerWeight(1, 0);
    }
}




