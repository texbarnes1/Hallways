using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Singleton Setup
    public static GameManager instance = null;

    public float time;
    public float maxTime = 15;

    //when the player is killed the gameOver float is set to a time and the game resets after said time
    public float gameOver = 0;
    public bool win = false;


    public int keys = 0; //the number of keys the player has;
    public float textDelay = 0; //when specific text needs to be delayed, this holds it on screen for a short time


    public GameObject player;

    public float maxMusicVolume = 0.85f;

    public GameObject musicLoad;

    GameObject musicBox;

    public float sprintDuration = 1f;
    public float sprintTimer = 0;
    public float sprintCooldown = 5f;
    public float sprintCooldownTimer = 0f;
    //technically canSprint is more: is sprinting
    public bool canSprint = true;

    // Awake Checks - Singleton setup
    void Awake() {
        musicBox = GameObject.Find("MusicBox");
        if (musicBox == null)
        {
            musicBox = (GameObject)Instantiate(musicLoad);
            musicBox.name = "MusicBox";
        }
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
	
	// Update is called once per frame
	void Update () {
        RenderSettings.ambientLight = new Color(0.02745098f * OptionsControls.brightness, 0.6313726f * OptionsControls.brightness, 0.5450981f * OptionsControls.brightness);
        
        time += Time.deltaTime;

        if (gameOver != 0 && time > gameOver)
        {
            musicBox.GetComponent<MusicBox>().music.volume = 0;
            if (win)
            {
                if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene("Start MenuTest");
                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
               

            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        //if the player is pressing shift:
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //if they are within a short sprint window they can sprint, otherwise they can't 
            if (sprintTimer < sprintDuration)
            {
                canSprint = true;
                sprintTimer += Time.deltaTime;
            }
            else
            {
                canSprint = false;
            }
            
        }
        else
        {
            canSprint = false;
        }
        
        //if the sprint lasts too long the player must wait for a cooldown
        if (sprintTimer > 0f && sprintCooldownTimer < sprintCooldown)
        {
            sprintCooldownTimer += Time.deltaTime;
        }
        else if (sprintTimer > 0)
        {
            sprintCooldownTimer = 0f;
            sprintTimer = 0f;
        }
	}
}
