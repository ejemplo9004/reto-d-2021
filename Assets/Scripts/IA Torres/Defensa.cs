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
        AtacarMonstruos();
    }
	void AtacarMonstruos(){
        Collider[] hitMonstruos = Physics.OverlapSphere(transform.position, attackRadio);
        if(hitMonstruos.Length > 0)
        {
            foreach (var monstruo in hitMonstruos)
            {
                if(monstruo.gameObject.CompareTag(enemyTag)){

                    timer += Time.fixedDeltaTime;

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