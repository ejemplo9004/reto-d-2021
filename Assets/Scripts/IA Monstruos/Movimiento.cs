using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 0.09f;
    public float currentSpeed;
    public MonsterState state;
    public Animator animator;

    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(target-transform.position* currentSpeed * Time.deltaTime);

        if(state == MonsterState.idle){
            StopCharacter();
        }
        else if(state == MonsterState.walking){
            MoveCharacter();
        }
        else if(state == MonsterState.attacking){
            Attack();
        }
        else if(state == MonsterState.dying){
            Dye();
        }

    }

    public void MoveCharacter(){
        currentSpeed = speed;
        SetAnimatorStatus(1);
    }

    public void StopCharacter(){
        currentSpeed = 0f;
        SetAnimatorStatus(0);
    }
    public void Attack(){
        currentSpeed = 0f;
        SetAnimatorStatus(2);
    }
    public void Dye(){
        currentSpeed = 0f;
        SetAnimatorStatus(3);
    }

    public void SetAnimatorStatus(int estado){
        animator.SetInteger("estado", estado);
    }



}
