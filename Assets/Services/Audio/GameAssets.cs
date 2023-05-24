using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;

    public void Awake()
    {
        if (i != null && i != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            i = this;
        }
        DontDestroyOnLoad(this.gameObject);        
    }

    public void Start()
    {
        Debug.Log("START GAME ASSETS");
        SoundManager.PlaySound(SoundManager.Sound.MusicBackgroundHome);
        
    }
    public void Update(){

    }
    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }
}
