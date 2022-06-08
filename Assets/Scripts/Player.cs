using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float health = 100;
    private float maxHealth;

    public GameObject mainCamera;

    public Camera camera;

    public float healthTimout = 2.5f;
    private float healthTimer = 0;
    public float healAdjust = 5;

    //UI Elements
    public Slider healthbar;
    public Image Bleed;

    public MusicBox music;

	// Use this for initialization
	void Start () {
        music = GameObject.Find("MusicBox").GetComponent<MusicBox>();
        maxHealth = health;
        healthbar.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(health < maxHealth)
        {
            //healthbar.gameObject.SetActive(true);
            healthTimer += Time.deltaTime;
            if (healthTimer > healthTimout)
            {
                takeDamage(-healAdjust * Time.deltaTime);
            }
        }
        else
        {
            healthbar.gameObject.SetActive(false);
            health = maxHealth;
            healthTimer = 0;
        }

        //if (GameManager.instance.canSprint)
        //{
        //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView,130f,Time.deltaTime * 5);
        //}
        //else
        //{
        //    camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 95f, Time.deltaTime * 5);
        //}
    }

    public void takeDamage(float dmg) {
        if (dmg > 0)
        {
            healthTimer = 0;
            music.Hit();
        }
        health -= dmg;

        healthbar.value = (health / maxHealth);

        Bleed.color = new Color(1, 1, 1,  (100 - health)/100);
        //print(health);
        if (health <= 0f) {
            mainCamera.SetActive(true);
            mainCamera.transform.position = transform.position;
            mainCamera.transform.rotation = transform.rotation;
            GameManager.instance.gameOver = GameManager.instance.time + 1; //sets the game over timer to 5 seconds
            Destroy(gameObject);
            //load back to main menu
            // SceneManager.LoadScene("Start menu");
        }
    }
}
