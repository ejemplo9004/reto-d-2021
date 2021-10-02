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
    public UnityEvent death;

    public void ReduceHealth(float dmg){
        health = Mathf.Clamp(actualHealth - dmg, 0, maxHealth);
        if(health == 0) death.invoke();
    }

    public void UpdateHealth()
    {
        if (uiHealthPercentage != null) uiHealthPercentage.value = this.GetHealthPercentage();
    }

    public float GetHealthPercentage()
    {
        return health / maxHealth;
    }
    
}
