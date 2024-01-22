using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeControl : MonoBehaviour
{    
    static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source =  GetComponent<AudioSource>();
        source.volume = GameController.audioVolume;    
    }

    // Update is called once per frame
    void Update()
    {
        source =  GetComponent<AudioSource>();
        source.volume = GameController.audioVolume;
    }
}
