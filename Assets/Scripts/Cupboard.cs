using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{
    public int keys = 1;
    public Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int search()
    {
        if (keys > 0){
            animation.Play();
            int keysHeld = keys;
            keys = 0;
            return keysHeld;
        }
        else
        {
            return 0;
        }
    }

    public void Open()
    {
    }

}
