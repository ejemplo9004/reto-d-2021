using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
                        Detectar();
                        if (actualTarget == null)
                        {
                            if(Vector3.SqrMagnitude(transform.position) < rangoAtaque*rangoAtaque) 
                                ChangeState(MonsterState.attacking);
                        }
                    }
                    break;
				case MonsterState.attacking:
                    if (saludEnemigo == null)
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

	public void Detectar()
	{
        Collider[] cols = Physics.OverlapSphere(transform.position, rangoVision, capaEdificios);
		if (cols.Length > 0)
		{
            float dMenor = 5000;
            int targetMasCercano = 0;
            for (var i = 0; i < cols.Length; i++)
            {
                float distancia = Vector3.SqrMagnitude(cols[i].transform.position - transform.position);
                if(distancia < dMenor){
                    targetMasCercano = i;
                    dMenor = distancia;
                }
            }
            ChangeTarget(cols[targetMasCercano].transform);
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

    public void Death(){
        ChangeState(MonsterState.dying);
        Invoke("Morir", 15f);
    }

    private void Morir(){
        Destroy(gameObject);
    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
         Handles.color = Color.red;
         Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
         Handles.DrawWireDisc(transform.position + Vector3.up*0.2f, Vector3.up, rangoVision); 
    }
#endif




}
public enum MonsterState
{
    idle = 0,
    walking = 1,
    attacking = 2,
    dying = 3
}
