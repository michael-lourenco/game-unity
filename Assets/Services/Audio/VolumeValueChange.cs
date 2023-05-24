using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    public BGSoundScript bgSoundScript = BGSoundScript.instance;
    

    // Music volume variable that will be modified
    // by dragging slider knob
    private float bgMusicVolume;
    private float musicVolume;

	// Use this for initialization
	void Start () {

        if (!ES3.KeyExists("bgMusicVolume"))
        {        
            ES3.Save("bgMusicVolume", 0.6f);
        }
        if (!ES3.KeyExists("musicVolume"))
        {        
            ES3.Save("musicVolume", 0.6f);
        }
        if (!ES3.KeyExists("bgMusicVolumeActive"))
        {        
            ES3.Save("bgMusicVolumeActive", true);
        }        
        if (!ES3.KeyExists("musicVolumeActive"))
        {        
            ES3.Save("musicVolumeActive", true);
        } 

        if(ES3.Load<float>("bgMusicVolume") != null){
            bgMusicVolume = ES3.Load<float>("bgMusicVolume");
        }
        else{
            ES3.Save("bgMusicVolume", 1f);
            bgMusicVolume = ES3.Load<float>("bgMusicVolume");
        }
        if(ES3.Load<float>("musicVolume") != null){
            musicVolume = ES3.Load<float>("musicVolume");
        }
        else{
            ES3.Save("musicVolume", 1f);
            musicVolume = ES3.Load<float>("musicVolume");
        }
      bgSoundScript.musicSource.volume = bgMusicVolume;
    
	}
	
	// Update is called once per frame
	public void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
       bgSoundScript.musicSource.volume = bgMusicVolume;
        
	}

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetMusicVolume(float vol)
    {
        ES3.Save("musicVolume", vol);  
        musicVolume =  vol;  
        bgSoundScript.musicSource.volume = vol;  
    }
    public void SetBGMusicVolume(float vol)
    {       
        ES3.Save("bgMusicVolume", vol);
        bgMusicVolume =  vol;
        bgSoundScript.musicSource.volume = vol;
    }
}

