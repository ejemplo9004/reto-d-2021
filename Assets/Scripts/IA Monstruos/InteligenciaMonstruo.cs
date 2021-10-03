using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteligenciaMonstruo : MonoBehaviour
{
    public static Vector3 mainTarget;
    public Vector3 actualTarget;
    
    public Animator animator;
    public Movimiento movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = this.gameObject.GetComponent<Movimiento>();
        // Define an initial target
        actualTarget = mainTarget;
        movement.target = mainTarget;
        movement.state = MonsterState.walking;
    }

    // Update is called once per frame
    void Update()
    {
        movement.target = actualTarget;

        if(Vector3.Distance(transform.position, actualTarget) < 1f){
            movement.state = MonsterState.attacking;
        }
        
    }

    public void ChangeState(){
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Enemy")){
            actualTarget = other.transform.position;
            
        }
    }

    

    

    

    

}
public enum MonsterState
{
    idle,
    walking,
    attacking,
    dying
}
