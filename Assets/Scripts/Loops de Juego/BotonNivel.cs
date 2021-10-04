using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonNivel : MonoBehaviour
{
    public Button boton;
    public Nivel controlNivel;


    // Start is called before the first frame update
    void Start()
    {
        ActivarBoton();
    }

    public void ActivarBoton(){
        
        boton.interactable = (PlayerPrefs.GetInt("nivel", 1) <= controlNivel.numNivel) ? false : true;
        Debug.Log(PlayerPrefs.GetInt("nivel", 1));
    }
}
