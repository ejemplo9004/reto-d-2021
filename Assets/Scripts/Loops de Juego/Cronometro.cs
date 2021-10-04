using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Cronometro : MonoBehaviour
{
    public Slider cronometro;
    public float tiempoTotal= 90f;
    [SerializeField] private float tiempoRestante;
    public UnityEvent tiempoAcabado = new UnityEvent();
    void Awake()
    {
        tiempoRestante = tiempoTotal;
    }
    void Start()
    {
        tiempoAcabado.AddListener(() => {Juego.singleton.AbrirMenuNiveles();});
    }
    // Update is called once per frame
    void Update()
    {
        if(tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            cronometro.value = tiempoRestante / tiempoTotal;
        }
        else tiempoAcabado.Invoke();
    }
}
