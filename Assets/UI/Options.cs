using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{

    public Slider music;
    public Slider effects;
    public Slider Brightness;
    // Start is called before the first frame update
    void Start()
    {
        Activated();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activated()
    {
        music.value = OptionsControls.musicVol;
        effects.value = OptionsControls.effectVol;
        Brightness.value = OptionsControls.brightness;
    }
    public void UpdateMusic()
    {
        OptionsControls.musicVol = music.value;
    }
    public void UpdateEffect()
    {
        OptionsControls.effectVol = effects.value;
    }
    public void UpdateBright()
    {
        OptionsControls.brightness = Brightness.value;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start MenuTest");
    }
}
