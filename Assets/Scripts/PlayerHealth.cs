using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; public float CurrentHealth { get; private set; }
    public bool IsAlive => CurrentHealth > 0;
    public event Action<float> HealthChanged; public event Action Died;
    void Awake() { CurrentHealth = maxHealth; }
    public void TakeDamage(float amount)
    {
        if (!IsAlive || amount <= 0) return;
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount); HealthChanged?.Invoke(CurrentHealth);
        if (CurrentHealth <= 0) Died?.Invoke();
    }
    public void Heal(float amount) { if (!IsAlive) return; CurrentHealth = Mathf.Min(maxHealth, CurrentHealth + Mathf.Max(0, amount)); HealthChanged?.Invoke(CurrentHealth); }
}
