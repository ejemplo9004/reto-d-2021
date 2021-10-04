using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{
    public int numNivel;
    public Transform torreEnemiga;
    public Transform torreAliada;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Juego.singleton.enJuego);
        StartCoroutine(TerminarNivel());
    }

    public IEnumerator TerminarNivel()
    {
        while (true)
        {
            if (torreEnemiga == null && Juego.singleton.enJuego)
            {
                Juego.singleton.enJuego = false;
                Juego.singleton.CompararNivel(numNivel);
                Debug.Log("Nivel superado. ¡Nivel " + PlayerPrefs.GetInt("nivel") + " superado!");
                Juego.singleton.AbrirMenuNiveles();
            }
            else if (torreAliada == null && Juego.singleton.enJuego)
            {
                Juego.singleton.enJuego = false;
                Juego.singleton.AbrirMenuNiveles();
            }

            yield return new WaitForSeconds(0.5f);
        }
    }






}
