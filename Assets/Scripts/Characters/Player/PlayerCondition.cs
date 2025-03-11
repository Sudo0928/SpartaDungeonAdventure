using System;
using UnityEngine;

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    private Condition health => uiCondition.health;
    private Condition hunger => uiCondition.hunger;
    private Condition stamina => uiCondition.stamina;

    public float noHungerHealthDecay;
    public event Action onTakeDamage;

    private void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue < 0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);

        if (health.curValue < 0f)
            Die();
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    private void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
}
