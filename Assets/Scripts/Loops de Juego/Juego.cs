using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Juego : MonoBehaviour
{
    public static Juego singleton;

    public int nivelAlcanzado = 0;
    public int nivelActual;
    public string[] niveles;


    void Start()
    {
        singleton = this;
    }


    public void SubirDeNivel(){
        nivelAlcanzado++;
    }


    public void SeleccionarNivel(int nivel){
        if(nivel <= nivelAlcanzado){
            nivelActual = nivel;
            SceneManager.LoadScene(niveles[nivel]);
        }
    }

    public void RepetirNivel(){
        SceneManager.LoadScene(niveles[nivelActual]);
    }
}
