using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollect : MonoBehaviour {

    public float hp = 100.0f;
    private float attackDmg = 12f;
    private bool dropped = false;
    private Animator anim;
    private BoxCollider box;
    public Animator childanim;
    private GameObject[] cloud;
    public GameObject drop;
    public Vector3 possition;
    private float timeToDestroy=7f;
    public bool isHitted = false;

    public bool IsHitted
    {
        get
        {
            return isHitted;
        }
        set
        {
            isHitted = value;
        }
    }


    void Start () {
        anim = GetComponentInChildren<Animator>();
        box = GetComponent<BoxCollider>();

        cloud = GameObject.FindGameObjectsWithTag("cloud");
        foreach(GameObject c in cloud)
        {
            if(c.transform.parent == transform.GetChild(0))
            {
                childanim = c.GetComponent<Animator>();
            }
        }
    }
	
	void Update () {


        if (hp <= 70.0 && hp>45.0)
        {
            if (!anim.GetBool("damaged"))
            {
                childanim.SetTrigger("test");
            }
            anim.SetBool("damaged", true);
        }

        if (hp <= 45.0 && hp>0)
        {
            if (!anim.GetBool("very_damaged"))
            {
                    childanim.SetTrigger("test");
            }
            anim.SetBool("damaged", false);
            anim.SetBool("very_damaged", true);
        }

        if (hp <= 0.0)
        {  
            if (!anim.GetBool("destroyed"))
            {
                childanim.SetTrigger("test");
            }

            if(dropped == false)
            {
                int r = Random.Range(1, 4);
                for (int i = 0; i < r; i++)
                {
                    Vector3 v3 = new Vector3(Random.Range(-3,3), Random.Range(-3,3), 0);
                    Instantiate(drop, transform.position + v3, transform.rotation);
                    FindObjectOfType<AudioManager>().Play("ItemDrop");
                    dropped = true;
                }
            }

            anim.SetBool("very_damaged", false);
            anim.SetBool("destroyed", true);
            Destroy(box);
            timeToDestroy -= Time.deltaTime;
            if(timeToDestroy<=0)
            {
                Destroy(gameObject);
            }
        }
 

    }
  

    void OnTriggerEnter (Collider col)
    {
        
        if (col.CompareTag("Hitbox") && isHitted==false)
        {
            FindObjectOfType<AudioManager>().Play("Mine");
            hp -= attackDmg;
            print("uderzono: "+hp);
            isHitted = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Hitbox") && isHitted == true)
        {
            isHitted = false;
        }
    }
}
