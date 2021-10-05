using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monja : MonoBehaviour
{
    public Animator animator;
    public Movimiento movement;
    public MonsterState state;
    public LayerMask capaEdificios;
    public Health saludEnemigo;
    [Header("Stats")]
    public float poder;
    public float rangoVision;
    public float rangoAtaque = 1.5f;


    void Start()
    {
        movement = this.gameObject.GetComponent<Movimiento>();
        // ChangeTarget();
        // ChangeState(MonsterState.walking);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTarget(Transform nT)
    {
        // actualTarget = nT;
        movement.target = (nT != null) ? nT.position : Vector3.zero;
    }

    public void CalcularTarget(float d){
        
    }
}
