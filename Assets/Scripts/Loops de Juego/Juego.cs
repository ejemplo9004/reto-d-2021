using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public static Juego singleton;

    void Start()
    {
        singleton = this;
        PlayerPrefs.SetInt("nivel", 1);
    }


    public void CompararNivel(int nivel){
        if(PlayerPrefs.GetInt("nivel", 1) < nivel){
            PlayerPrefs.SetInt("nivel", nivel);
        }
    }

    


    
}
