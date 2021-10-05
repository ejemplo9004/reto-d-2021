using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monja : MonoBehaviour
{
    public Animator animator;
    public Movimiento movement;
    public MonsterState state;
    public float distancia;
    [Header("Stats")]
    public float poder;
    public float rangoVision;
    public float rangoAtaque = 1.5f;


    void Start()
    {
        movement = this.gameObject.GetComponent<Movimiento>();
        CalcularTarget();
        ChangeState(MonsterState.walking);
        StartCoroutine(Estados());
    }

    public IEnumerator Estados()
    {
        while (true)
        {
            switch (state)
            {
                case MonsterState.idle:
                    break;
                case MonsterState.walking:
                    if (movement.target != null && Vector3.SqrMagnitude(transform.position - movement.target) < rangoAtaque * rangoAtaque)
                    {
                        ChangeState(MonsterState.attacking);
                    }
                    break;
                case MonsterState.attacking:
                    break;
                case MonsterState.dying:
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ChangeState(MonsterState nS)
    {
        switch (nS)
        {
            case MonsterState.idle:
                movement.StopCharacter();
                break;
            case MonsterState.walking:
                movement.MoveCharacter();
                break;
            case MonsterState.attacking:
                movement.StopCharacter();
                break;
            case MonsterState.dying:
                movement.StopCharacter();
                break;
            default:
                break;
        }
        state = nS;
        animator.SetInteger("estado", (int)nS);

    }

    public void Death()
    {
        ChangeState(MonsterState.dying);
        Invoke("Morir", 20f);
    }

    private void Morir()
    {
        Destroy(gameObject);
    }

    public void CalcularTarget(){
        Vector3 target = transform.position + new Vector3(Random.Range(-distancia,distancia), 0f, Random.Range(-distancia,distancia));
        movement.target = target;
    }
}
