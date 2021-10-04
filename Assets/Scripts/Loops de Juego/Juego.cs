using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public static Juego singleton;
    public bool enJuego;

    // public static Juego Instance { get {return singleton; } }

    private void Awake() {
        singleton = this;
    }

    void Start()
    {
        enJuego = true;
    }


    public void CompararNivel(int nivel){
        if(PlayerPrefs.GetInt("nivel", 1) < nivel + 1){
            PlayerPrefs.SetInt("nivel", nivel + 1);
        }
    }

    public void ResetNiveles(){
        PlayerPrefs.SetInt("nivel", 1);
    }

    public void AbrirMenuNiveles(){
        SceneManager.LoadScene("MenuNiveles");
    }
    


    
}
