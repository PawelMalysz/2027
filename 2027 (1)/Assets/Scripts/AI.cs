using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    private NavMeshAgent nav;
    private GameObject target;
    private GameObject rocket;
    public float hp= 100f;
    private float cHp;
    private float range;
    public Image enemyHB;
    private LightController lc;



    public float attackDmg = 10f;
    private float attackCooldown = 3f;
    private float currentAttackCooldown;
    private Vector3 v;
    private Animator anim;
    private bool attention=false;

    public Image warning;
    
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        lc = FindObjectOfType<LightController>();
        rocket = GameObject.FindGameObjectWithTag("Rocket");
    }

	void Start () {

        nav.Warp(transform.position);
        target = GameObject.FindGameObjectWithTag("Player");
        cHp = hp;
        anim = GetComponentInChildren<Animator>();
	}
	
	void Update () {
        range = Mathf.Pow( Mathf.Pow((target.transform.position.x - transform.position.x),2)
            + Mathf.Pow((target.transform.position.z - transform.position.z),2), 0.5f);


            if (range < 7f)
            {
                // warning.enabled = true;
                nav.SetDestination(target.transform.position);
                if (attention == true && range < 7f)
                {
                    FindObjectOfType<AudioManager>().Play("monsterAttention");
                    attention = false;
                }


                currentAttackCooldown -= Time.deltaTime;
                anim.SetLayerWeight(2, 1);

                if (currentAttackCooldown <= 2.5 && currentAttackCooldown >= 1)
                {
                    anim.SetBool("en_Attack", false);
                }
            }
        else
        if (lc.t > 0.75f)
        {
            nav.SetDestination(rocket.transform.position);
        }
        else
            if (lc.t < 0.75f)
        {
            nav.isStopped = true;
        }




        if (transform.position.x == nav.destination.x)
                anim.SetLayerWeight(2, 0);

            if (range < 2f)
            {
                Attack();
                anim.SetLayerWeight(2, 0);
            }

            if (range < 1.5f && nav.isActiveAndEnabled)
            {
                nav.isStopped = true;

            }
            else if (nav.isActiveAndEnabled)
                nav.isStopped = false;

   


    }

    void OnTriggerEnter(Collider col)
    {

        if (col.CompareTag("Hitbox"))
        {
            cHp -= 10;
            print("hitted: " + cHp);
            enemyHB.fillAmount = cHp / hp;
            v = 2 * (target.transform.position - transform.position);

            FindObjectOfType<AudioManager>().Play("monsterDamaged");

            if (cHp <= 20)
            {
                enemyHB.color = new Color(255, 0, 0);
            }
        }
        if (cHp <= 0)
            GameObject.Destroy(gameObject);
    }

    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("monsterAttack");


        if (currentAttackCooldown < 0)
        {
            v = 2*(transform.position - target.transform.position);
            FindObjectOfType<PlayerControler>().TakeDmg(attackDmg, v);


            anim.SetBool("en_Attack", true);

            currentAttackCooldown = attackCooldown;      
        }
    }

 
}
