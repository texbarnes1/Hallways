using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChairEnemy : MonoBehaviour
{

    NavMeshAgent agent;

    //public float health = 100;
    public float detectionRadius = 0f;

    public GameObject target;

    private float damage = 25;
    private float damageTime;
    private float damageRate = 0.5f;

    //Effects
    public GameObject deathEffect;

    //Cupboard Animators 
    //public Animator rightAnimate;
    //public Animator leftAnimate;
    public GameObject cupboard;
    //private float scale = 2; //the scale of the cupboard

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Player Reference exception catching
        try
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        catch
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // If the target is nearby, navigate toward its position
        float proxy = Vector3.Distance(transform.position, target.transform.position);

        if (proxy <= detectionRadius)
        {
            // Move toward the player
            agent.destination = target.transform.position;
            // Open doors
            //float proxy = Vector3.Distance(transform.position, target.transform.position);
            //rightAnimate.SetFloat("Proxy", Mathf.RoundToInt(proxy));
            //leftAnimate.SetFloat("Proxy", Mathf.RoundToInt(proxy));
        }

        //// If the target exists, navigate towards its position
        //if (target)
        //{
        //    agent.destination = target.transform.position;

        //    //If the player is nearby open the cupboard doors
        //    float proxy = Vector3.Distance(transform.position, target.transform.position);
        //    rightAnimate.SetFloat("Proxy", Mathf.RoundToInt(proxy));
        //    leftAnimate.SetFloat("Proxy", Mathf.RoundToInt(proxy));
        //    //Also, scale up the cupboard when it gets close!
        //    float scaling = Mathf.Max(2, 3.25f - proxy / 6);
        //    scale = Mathf.Lerp(scale, scaling, Time.deltaTime * 0.75f);
        //    cupboard.transform.localScale = new Vector3(scale, scale, scale);
        //}
    }

    ////Public method for taking damage and dying
    //public void takeDamage(float dmg)
    //{
    //    health -= dmg;

    //    if (health <= 0)
    //    {
    //        Destroy(this.gameObject);
    //        Instantiate(deathEffect, transform.position, transform.rotation);
    //    }
    //}

    private void OnTriggerStay(Collider otherObject)
    {

        if (otherObject.transform.tag == "Player" && Time.time > damageTime)
        {
            otherObject.GetComponent<Player>().takeDamage(damage);
            damageTime = Time.time + damageRate;
        }
    }
}
