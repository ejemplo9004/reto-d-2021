using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonNivel : MonoBehaviour
{
    public Button boton;  // Es el mismo boton
    public int nivel;
     // public Nivel controlNivel; // Lo tendrá la torre


    // Start is called before the first frame update
    void Start()
    {
        ActivarBoton();
    }

    public void ActivarBoton(){
        
        boton.interactable = (nivel <= PlayerPrefs.GetInt("nivel", 1)) ? true : false;
        Debug.Log(PlayerPrefs.GetInt("nivel", 1));
    }

    public void AbrirNivel(string scene){
        SceneManager.LoadScene(scene);
    }
}
