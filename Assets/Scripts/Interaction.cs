using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    //used for targeting
    public GameObject muzzle;
    public GameObject target;

    //UI Elements for interacting with
    public TMPro.TextMeshProUGUI interaction;
    public TMPro.TextMeshProUGUI keycount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    //checks if the player is looking at an interactable object, and gives the player a queue that they can interact with 'E'
    void Interact()
    {
        //Raycast Projectile
        RaycastHit hit;

        if (Physics.Raycast(muzzle.transform.position, -(muzzle.transform.position - target.transform.position).normalized, out hit, 3.0f))
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
            //Find Door;
            else if (hit.transform.tag == "Door")
            {
                if (GameManager.instance.time > GameManager.instance.textDelay)
                {
                    interaction.text = "Press 'E' to open door";
                }

                if (Input.GetKeyDown("e")) //when you press 'E' on a cupboard it adds any keys held to your keycount, and displays this to the player
                {
                    int keysNeeded = hit.transform.GetComponent<Door>().Check();
                    if (keysNeeded > GameManager.instance.keys)
                    {
                        interaction.text = "This door needs " + keysNeeded + " keys to open";
                    }
                    else
                    {
                        interaction.text = "The door opens";
                        GameManager.instance.gameOver = GameManager.instance.time + 0.5f; //sets the game over timer to 5 seconds
                    }
                    GameManager.instance.textDelay = GameManager.instance.time + 2.0f;
                }
            }
            else
            {
                if (GameManager.instance.time > GameManager.instance.textDelay - 1f)
                {
                    interaction.text = "";
                }
            }
        }
        else
        {
            if (GameManager.instance.time > GameManager.instance.textDelay-1f)
            {
                interaction.text = "";
            } 
        }

    }
}
