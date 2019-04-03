using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;
    private Quaternion hitbox_direction;
    private GameObject hitbox;
    private Vector3 hitbox_dir;
    private bool isAttacking = false;

    void Start()
    {

        anim = GetComponent<Animator>();
        hitbox = GameObject.FindGameObjectWithTag("Hitbox");

    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        anim.SetFloat("x", x);
        anim.SetFloat("y", y);

        if (Input.GetKey(KeyCode.Space))
        {
            isAttacking = true;
            anim.SetBool("Attack", true);
        }
        else
            anim.SetBool("Attack", false);



        if (x > 0)
        {
            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
        }
        if (x < 0)
        {
            anim.SetBool("Right", false);
            anim.SetBool("Left", true);
        }

        if (y == 0 && x == 0)//idle
        {
            anim.SetLayerWeight(1, 0);
            if (isAttacking == true)
            {
                anim.SetLayerWeight(2, 1);
            }
            else
                anim.SetLayerWeight(2, 0);
        }   
        else//run
        {
            anim.SetLayerWeight(1, 1);
            isAttacking = false;
        }





        if (!transform.parent.GetComponent<PlayerControler>().isHitting)
        {

            if (x > 0 && y == 0)//Right
            {
                //hitbox_direction = Quaternion.Euler(0f, 60f, 30f);
                hitbox_dir = new Vector3(0, 60f, 30f);
            }
            if (x < 0 && y == 0)//Left
            {
                //hitbox_direction = Quaternion.Euler(45, -150f, 30);
                hitbox_dir = new Vector3(0, -150f, 30f);
            }
            if (y > 0 && x == 0)//Up
            {
                //hitbox_direction = Quaternion.Euler(0, -60f, 30);
                hitbox_dir = new Vector3(0, -60f, 30f);
            }
            if (y < 0 && x == 0)//Down
            {
                //hitbox_direction = Quaternion.Euler(0, 120f, 30);
                hitbox_dir = new Vector3(0, 120f, 30f);
            }
            if (y < 0 && x < 0)//LeftDown
            {
                //hitbox_direction = Quaternion.Euler(0, -105f, 30);
                hitbox_dir = new Vector3(0, -105f, 30f);
            }
            if (y < 0 && x > 0)//RightDown
            {
                //hitbox_direction = Quaternion.Euler(0, -15f, 30);
                hitbox_dir = new Vector3(0, -15f, 30f);
            }
            if (y > 0 && x < 0)//LeftUp
            {
                //hitbox_direction = Quaternion.Euler(0, -195f, 30);
                hitbox_dir = new Vector3(0, -195f, 30f);
            }
            if (y > 0 && x > 0)//RightUp
            {
                //hitbox_direction = Quaternion.Euler(0, 75, 30);
                hitbox_dir = new Vector3(0, 75f, 30f);
            }
            //hitbox.transform.rotation = hitbox_direction;
            hitbox.transform.localEulerAngles = hitbox_dir;
        }

    }

}