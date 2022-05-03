using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    Animation animation;

    //damage variables 
    public float damage = 10.0f;
    public float fireRate = 0.15f;
    private float fireTime;

    //Spawn Effects and target objects
    public GameObject muzzleFlash;
    public GameObject bulletHit;
    public GameObject muzzle;
    public GameObject target;

    //audio effect
    public GameObject fireSound;

    //UI Elements for interacting with
    public TMPro.TextMeshProUGUI interaction;
    public TMPro.TextMeshProUGUI keycount;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        WeaponFiring();

        Interact();
    }

    void WeaponFiring()
    {
        if(Input.GetMouseButton(0) && Time.time > fireTime)
        {

            //Fire effects
            Instantiate(fireSound, transform.position, transform.rotation);
            Instantiate(muzzleFlash, muzzle.transform.position, muzzle.transform.rotation);
            animation.Play("Fire");

            //Raycast Projectile
            RaycastHit hit;

            if (Physics.Raycast(muzzle.transform.position, -(muzzle.transform.position - target.transform.position).normalized, out hit, 50.0f))
            {
                //Damage Enemies;
                if(hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().takeDamage(damage);
                }

                Instantiate(bulletHit, hit.transform.position, hit.transform.rotation);
                
            }

            //setup next time to fire
            fireTime = Time.time + fireRate;


        }
    }

    //checks if the player is looking at an interactable object, and gives the player a queue that they can interact with 'E'
    void Interact()
    {
        //Raycast Projectile
        RaycastHit hit;

        if (Physics.Raycast(muzzle.transform.position, -(muzzle.transform.position - target.transform.position).normalized, out hit, 2.0f))
        {
            //Find Cupboards;
            if (hit.transform.tag == "Cupboard")
            {
                if (GameManager.instance.time > GameManager.instance.textDelay)
                {
                    interaction.text = "Press 'E' to search cupboard";
                }
                
                if (Input.GetKeyDown("e")) //when you press 'E' on a cupboard it adds any keys held to your keycount, and displays this to the player
                {
                    int keysfound = hit.transform.GetComponent<Cupboard>().search();
                    GameManager.instance.keys += keysfound;
                    keycount.text = "Keys: " + GameManager.instance.keys;

                    GameManager.instance.textDelay = GameManager.instance.time + 2.0f;
                    if (keysfound == 1)
                    {
                        interaction.text = "You found a key";
                    }
                    else 
                    {
                        interaction.text = "You found " + keysfound + " keys";
                    }
                        

                }
            }
            else
            {
                interaction.text = "";
            }
        }
        else
        {
            interaction.text = "";
        }
    }
}
