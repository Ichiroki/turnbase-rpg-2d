using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public BattleManager battleManager;

    public void OnAttackButton()
    {
        battleManager.EnterTargetSelection();
    }
}