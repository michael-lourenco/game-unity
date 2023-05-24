using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundData : MonoBehaviour
{
    public void SaveSoundData(bool value){
        ES3.Save("muted", value);
    }

    public bool LoadSoundData(){
        bool soundRecived = new bool();
        if (!ES3.KeyExists("muted"))
        {
            ES3.Save("muted", false);   
        }else{
            soundRecived =  ES3.Load<bool>("muted");
        }
        return soundRecived;
    }

    public void ResetSoundData(){
        if (!ES3.KeyExists("muted"))
        {
            ES3.Save("muted", false);
        }else{
            ES3.Save("muted", false);
        }

    }
}