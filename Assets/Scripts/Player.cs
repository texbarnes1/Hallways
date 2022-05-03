using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    public GameObject mainCamera;

    //UI Elements
    public Slider healthbar;

	// Use this for initialization
	void Start () {
        maxHealth = health;
        healthbar.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(health < 100)
        {
            healthbar.gameObject.SetActive(true); 
        }
	}

    public void takeDamage(float dmg) {
        health -= dmg;

        healthbar.value = (health / maxHealth);
        //print(health);
        if (health <= 0f) {
            mainCamera.SetActive(true);
            mainCamera.transform.position = transform.position;
            mainCamera.transform.rotation = transform.rotation;
            GameManager.instance.gameOver = GameManager.instance.time + 5; //sets the game over timer to 5 seconds
            Destroy(gameObject);
        }
    }
}
