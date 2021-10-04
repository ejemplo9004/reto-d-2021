using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{
    public bool nivelTerminado;
    public int numNivel;
    public Transform torreEnemiga;
    public Transform torreAliada;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TerminarNivel());
        
    }

    public IEnumerator TerminarNivel()
    {
        while (true)
        {
            if (torreEnemiga == null && !nivelTerminado){
                nivelTerminado = true;
                Juego.singleton.CompararNivel(numNivel);
                Time.timeScale = 0;
                Debug.Log(PlayerPrefs.GetInt("nivel", 1));
            }
            else if(torreAliada == null && !nivelTerminado){
                Time.timeScale = 0;
                nivelTerminado = true;
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }

    

    


}
