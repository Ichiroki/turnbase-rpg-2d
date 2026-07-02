using UnityEngine;

public class BattleSlot : MonoBehaviour
{
    [Header("Parent")]
    public BattleManager battleManager;

    [Header("Slot Data")]
    public bool isOccupied;
    public CharacterStats occupant;

    public HealthBar health;

    [Header("Visual")]
    private SpriteRenderer spriteRenderer;

    private Color defaultColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            defaultColor = spriteRenderer.color;
        }
    }

    public void SetOccupant(CharacterStats character)
    {
        occupant = character;
        isOccupied = character != null;

        if (occupant != null)
        {
            health.SetActive(true);
            health.SetTarget(occupant);
        }
        else
        {
            health.SetActive(false);
        }
    }

    public void ClearSlot()
    {
        occupant = null;
        isOccupied = false;

        health.SetActive(false);
    }

    public void Highlight()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.yellow;
        }
    }

    public void UnHighlight()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor;
        }
    }

    public bool HasTarget()
    {
        return isOccupied && occupant != null;
    }

    public void OnMouseDown()
    {
        if (!battleManager.selectingTarget)
            return;

        if (!HasTarget())
            return;

        battleManager.HitTargetSelection(this);
    }

    public void RemoveOccupant()
    {
        if (occupant != null)
        {
            Destroy(occupant.gameObject);
        }

        ClearSlot();
    }
}