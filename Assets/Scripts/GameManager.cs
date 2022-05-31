﻿using System.Collections;
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


    // Awake Checks - Singleton setup
    void Awake() {

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
        time += Time.deltaTime;

        if (gameOver != 0 && time > gameOver)
        {
            if (win)
            {
                if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene("Start menu");
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
	}
}
