using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    public Slider slider; 

    void Start()
    {
        Player.OnHealthChanged -= UpdateHealthBar; 
        Player.OnHealthChanged += UpdateHealthBar;
        
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }
    
    void OnDestroy()
    {
        Player.OnHealthChanged -= UpdateHealthBar;
    }
    
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (slider != null)
        {
            slider.maxValue = maxHealth;
            
            slider.value = currentHealth;
            
            Debug.Log($"Health Bar Updated: {currentHealth}/{maxHealth}");
        }
    }
}