using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectModifier : MonoBehaviour
{
    public float MaxVolume = 1f;

    AudioSource Sound;
    // Start is called before the first frame update
    void Start()
    {
        Sound = gameObject.GetComponent<AudioSource>();
        MaxVolume = Sound.volume;
    }

    // Update is called once per frame
    void Update()
    {
       if (Sound.volume != OptionsControls.effectVol * MaxVolume)
        {
            Sound.volume = OptionsControls.effectVol * MaxVolume;
        }
    }
}
