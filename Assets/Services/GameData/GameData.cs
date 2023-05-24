using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    //public UniversoBlueprint universo;

    //public BiomaBlueprint bioma;
   // public Dictionary<BiomaSlot, GameObject>
      //  itemsExibidos = new Dictionary<BiomaSlot, GameObject>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        VerificaSeDadosDeConfiguracaoExistemEInsereCasoNaoExista();

        
        addLong(10,"currentGold");
        var gold = getGold();
        Debug.Log("gold "+ gold.ToString());
    }

    public void VerificaSeDadosDeConfiguracaoExistemEInsereCasoNaoExista()
    {
        Debug.Log("VerificaSeDadosDeConfiguracaoExistemEInsereCasoNaoExista");
        // CONFIG GAME DATA
        if (!ES3.KeyExists("startTime"))
        {
            Debug.Log("NAO EXISTE START TIME");
            DateTime horarioQueIniciouJogo = DateTime.UtcNow;
            ES3.Save("startTime", horarioQueIniciouJogo.ToBinary());
        }

        if (!ES3.KeyExists("currentMainTime"))
        {
            Debug.Log("NAO EXISTE CURRENT MAIN TIME");
            DateTime horarioQueParouJogo = DateTime.UtcNow;
            ES3.Save("currentMainTime", horarioQueParouJogo.ToBinary());
        }

        
        if (!ES3.KeyExists("currentGold"))
        {
            ES3.Save("currentGold", Convert.ToInt64(0));
        }
        

        if (!ES3.KeyExists("currentNumberCreatures"))
        {
            ES3.Save("currentNumberCreatures",Convert.ToInt64(0));
        }

        if (!ES3.KeyExists("currentCreatureToSpawn"))
        {
            ES3.Save("currentCreatureToSpawn", "Fruit_Blue_1");
        }

        if (!ES3.KeyExists("spawnDelay"))
        {
            ES3.Save("spawnDelay", 5);
        }

        // CONFIG SETTINGS
        if (!ES3.KeyExists("bgMusicVolume"))
        {
            ES3.Save("bgMusicVolume",0.6f);
        }

        if (!ES3.KeyExists("musicVolume"))
        {
            ES3.Save("musicVolume", 0.6f);
        }

        if (!ES3.KeyExists("bgMusicVolumeActive"))
        {
            ES3.Save("bgMusicVolumeActive", true);
        }

        if (!ES3.KeyExists("language"))
        {
            ES3.Save("language", "portuguese");
        }

        if (!ES3.KeyExists("muted"))
        {
            ES3.Save("muted", false);
        }
    }

    public void ResetGameStatistics()
    {
        if (!ES3.KeyExists("currentGold"))
        {
            ES3.Save("currentGold", 0);
        }
        else
        {
            ES3.Save("rankingPlayerX", 0);
        }
    }

    public void ResetGameSettings()
    {
        if (!ES3.KeyExists("bgMusicVolume"))
        {
            ES3.Save("bgMusicVolume", 0.6f);
        }
        else
        {
            ES3.Save("bgMusicVolume", 0.6f);
        }

        if (!ES3.KeyExists("musicVolume"))
        {
            ES3.Save("musicVolume", 0.6f);
        }
        else
        {
            ES3.Save("musicVolume", 0.6f);
        }

        if (!ES3.KeyExists("bgMusicVolumeActive"))
        {
            ES3.Save("bgMusicVolumeActive",true);
        }
        else
        {
            ES3.Save("bgMusicVolumeActive", true);
        }

        if (!ES3.KeyExists("muted"))
        {
            ES3.Save("muted", false);
        }
        else
        {
            ES3.Save("muted", false);
        }

        if (!ES3.KeyExists("language"))
        {
            ES3.Save("language", "portuguese");
        }
        else
        {
            ES3.Save("language", "portuguese");
        }
    }

    public void addInt(int value, string variavel)
    {
        if (!ES3.KeyExists(variavel))
        {
            if (value == -1)
            {
                value = 0;
            }
            ES3.Save (variavel, value);
        }
        else
        {
            int currentValue = ES3.Load<int>(variavel);
            currentValue += value;
            ES3.Save (variavel, currentValue);
        }
    }

    public int getInt(string variavel)
    {
        if (!ES3.KeyExists(variavel))
        {
            ES3.Save(variavel, 0);
            return ES3.Load<int>(variavel);
        }
        else
        {
            return ES3.Load<int>(variavel);
        }
    }

    public void addLong(long value, string variavel)
    {
        if (!ES3.KeyExists(variavel))
        {
            if (value == -1)
            {
                value = 0;
            }
            ES3.Save (variavel,Convert.ToInt64(value));
        }
        else
        {
            long currentValue = ES3.Load<long>(variavel);
            currentValue += value;
            ES3.Save (variavel,Convert.ToInt64(currentValue));
        }
    }

    public long getLong(string variavel)
    {
        if (!ES3.KeyExists(variavel))
        {
            ES3.Save(variavel, Convert.ToInt64(0));
            return ES3.Load<long>(variavel);
        }
        else
        {
            return ES3.Load<long>(variavel);
        }
    }

    public string getCurrentCreatureToSpawn()
    {
        if (!ES3.KeyExists("currentCreatureToSpawn"))
        {
            ES3.Save("currentCreatureToSpawn","Fruit_Blue_1");
            return ES3.Load<string>("currentCreatureToSpawn");
        }
        else
        {
            return ES3.Load<string>("currentCreatureToSpawn");
        }
    }

    public long getGold() {
        return getLong("currentGold");
    }

    public void setGold(long value){
        addLong(value, "currentGold");
    }
}
