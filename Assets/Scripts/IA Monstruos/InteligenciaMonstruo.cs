using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteligenciaMonstruo : MonoBehaviour
{
    public Transform actualTarget;
    
    public Animator animator;
    public Movimiento movement;
    public MonsterState state;
    public LayerMask capaEdificios;
    public Health saludEnemigo;
    [Header("Stats")]
    public float poder;
    public float rangoVision;
    public float rangoAtaque = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        movement = this.gameObject.GetComponent<Movimiento>();
        // Define an initial target
        ChangeTarget();
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
                    if (actualTarget != null && Vector3.SqrMagnitude(transform.position - actualTarget.position) < rangoAtaque*rangoAtaque)
                    {
                        ChangeState(MonsterState.attacking);
                    }
                    else
                    {
                        if (actualTarget == null && Vector3.SqrMagnitude(transform.position) < 2.25f)
                        {
                            ChangeState(MonsterState.attacking);
                        }
                    }
                    break;
				case MonsterState.attacking:
                    if (actualTarget == null)
                    {
                        ChangeTarget();
                        ChangeState(MonsterState.walking);
                    }
					if (saludEnemigo != null)
					{
                        saludEnemigo.ReduceHealth(poder/2f);
					}
                    break;
				case MonsterState.dying:
					break;
				default:
					break;
			}
            yield return new WaitForSeconds(0.5f);
		}
	}

	private void FixedUpdate()
	{
        Collider[] cols = Physics.OverlapSphere(transform.position, rangoVision, capaEdificios);
		if (cols.Length > 0)
		{
            ChangeTarget(cols[0].transform);
		}
		
	}

	public void ChangeTarget(Transform nT = null)
	{
        actualTarget = nT;
        movement.target = (nT != null)?  nT.position: Vector3.zero;
		if (nT != null)
		{
            saludEnemigo = nT.GetComponent<Health>();
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

    private void OnTriggerEnter(Collider other) {
        if(other.tag.Equals("Enemy")){
            actualTarget = other.transform;
        }
    }



	private void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoVision);
	}





}
public enum MonsterState
{
    idle = 0,
    walking = 1,
    attacking = 2,
    dying = 3
}
