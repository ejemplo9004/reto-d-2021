using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed;
    public float currentSpeed;

    public Vector3 target;

    void Update()
    {
        Vector3 direccion = (target - transform.position).normalized;
        transform.forward = direccion;
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

    }

    public void MoveCharacter(){
        currentSpeed = speed;
    }

    public void StopCharacter(){
        currentSpeed = 0f;
    }



}
