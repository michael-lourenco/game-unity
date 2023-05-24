using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{
    // fonte: https://www.youtube.com/watch?v=82Mn8v55nr0
    public static BGSoundScript instance;
    public AudioSource musicSource;
    // PlayGlobal



    public void Awake()
    {
        if(instance!=null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
        
        PlayMusic(this.musicSource.clip);
    }
    void Update(){
        musicSource.volume = ES3.Load<float>("bgMusicVolume");
    }


    public void PlayMusic(AudioClip clip)//We don't need Play for your problem.
    {
        musicSource.clip = clip;
        musicSource.volume = ES3.Load<float>("bgMusicVolume");
        musicSource.Play ();
    }

    public void StopMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Stop ();
    }
    //Play Global End
}
