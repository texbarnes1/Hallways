using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{

    public AudioSource music;
    public float heal = 2;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        music = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (music.volume != OptionsControls.musicVol)
        {
            music.volume = Mathf.Lerp(music.volume, OptionsControls.musicVol, Time.unscaledDeltaTime * heal);
        }
    }

    public void Hit()
    {
        music.volume = 0;
    }
}
