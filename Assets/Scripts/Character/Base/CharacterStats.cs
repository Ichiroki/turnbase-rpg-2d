using UnityEngine;
using System;

public class CharacterStats : MonoBehaviour
{
    public string characterName;

    public Action OnHealthChanged;

    public int maxHP = 100;
    public int currentHP;

    public int attack = 10;
    public int defense = 5;

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if(currentHP < 0)
            currentHP = 0;

        OnHealthChanged?.Invoke();
    }

    public bool IsDead()
    {
        return currentHP < 1;
    }
}
