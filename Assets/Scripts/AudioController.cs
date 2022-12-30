using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            music.Play();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            music.Stop();
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            music.Pause();
        }
    }
}
