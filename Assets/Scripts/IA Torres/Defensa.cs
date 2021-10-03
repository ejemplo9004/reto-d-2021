using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Defensa : MonoBehaviour
{
    public float dps = 1f;
    public float attackRadio = 2f;  
    public string enemyTag = "Player";
    public UnityEvent attackMode;
    private float timer = 0f;
    void FixedUpdate()
    {
        AtacarMonstruos(attackRadio, enemyTag);
    }
	void AtacarMonstruos(float radio, string tag){
        Collider[] hitMonstruos = Physics.OverlapSphere(transform.position, radio);
        if(hitMonstruos.Length > 0)
        {
            foreach (var monstruo in hitMonstruos)
            {
                if(monstruo.gameObject.CompareTag(tag)){

                    timer += Time.deltaTime;

                    if(timer >= dps){
                        attackMode.Invoke();
                        monstruo.GetComponent<Health>().ReduceHealth(10f);
                        timer = 0f;
                    }
                    
                }
            }
        }
    }
    
}