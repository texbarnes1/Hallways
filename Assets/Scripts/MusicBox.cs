using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public AudioSource music;
    public float heal = 2;
    // Start is called before the first frame update
    void Start()
    {
        music = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (music.volume != GameManager.instance.maxMusicVolume)
        {
            music.volume = Mathf.Lerp(music.volume, GameManager.instance.maxMusicVolume, Time.deltaTime * heal);
        }
    }

    public void Hit()
    {
        music.volume = 0;
    }
}
