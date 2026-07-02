using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;

    private CharacterStats target;

    public void UpdateHealth()
    {
        if (target == null)
            return;

        float percent =
            (float)target.currentHP / target.maxHP;

        bar.fillAmount = percent;

        Debug.Log(bar);
        Debug.Log(target);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public void SetTarget(CharacterStats stats)
    {
        target = stats;

        target.OnHealthChanged += UpdateHealth;

        UpdateHealth();
    }

    private void OnDisable()
    {
        if(target != null)
            target.OnHealthChanged -= UpdateHealth;
    }
}