using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioSource[] audioSource;
    public static AudioManagement instance;
    public AudioSource bmgAudioMusic;
    public void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySfx(int sfxToPlay)
    {
        audioSource[sfxToPlay].Play();
    }
}
