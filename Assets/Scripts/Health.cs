using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public Slider uiHealthPercentage;
    public bool autoDestruir = true;
    public UnityEvent death;

	private void Start()
	{
        health = maxHealth;
	}
	public void ReduceHealth(float dmg){
        health -= dmg;
        if (health <= 0)
        {
            death.Invoke();
			if (autoDestruir)
			{
                Destroy(gameObject);
			}
        }
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (uiHealthPercentage != null) 
            uiHealthPercentage.value = this.GetHealthPercentage();
    }

    public float GetHealthPercentage()
    {
        return health / maxHealth;
    }
    
}
