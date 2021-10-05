using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonInvisible : MonoBehaviour
{
    public int indice;
    void Start()
    {
        int r0 = PlayerPrefs.GetInt("c0");
        int r1 = PlayerPrefs.GetInt("c1");
        int r2 = PlayerPrefs.GetInt("c2");
        int r3 = PlayerPrefs.GetInt("c3");

        if (r0 == indice || r1 == indice || r2 == indice || r3 == indice)
		{
            gameObject.SetActive(true);
		}
		else
		{
            gameObject.SetActive(false);
		}
    }

}
