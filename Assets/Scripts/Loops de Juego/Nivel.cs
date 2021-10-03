using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    public bool nivelTerminado;
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
                Juego.singleton.SubirDeNivel();
            }
            else if(torreAliada == null && !nivelTerminado){
                nivelTerminado = true;
            }
            
            yield return new WaitForSeconds(0.5f);
        }
    }


}
