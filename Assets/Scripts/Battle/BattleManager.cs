using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public TurnState state;

    public BattleSlot[] playerSlots;
    public BattleSlot[] enemySlots;

    public CharacterStats player;

    public CharacterAnimation playerAnim;

    public ResultBattleUI result;

    public bool selectingTarget = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SpawnPlayer();
        SpawnEnemies();

        state = TurnState.PlayerTurn;
    }
    
    private IEnumerator PlayerAttack(BattleSlot targetSlot)
    {
        if (state != TurnState.PlayerTurn)
            yield break;

        CharacterStats enemy = targetSlot.occupant;
        CharacterAnimation enemyAnim =
            enemy.GetComponent<CharacterAnimation>();

        yield return StartCoroutine(
            playerAnim.AttackRoutine(
                enemyAnim,
                Vector3.left
            )
        );
        enemy.TakeDamage(player.attack);

        if (enemy.IsDead())
        {
            enemyAnim.PlayDeath();

            yield return new WaitForSeconds(0.5f);

            targetSlot.RemoveOccupant();

            bool allEnemiesDead = true;

            foreach (BattleSlot slot in enemySlots)
            {
                if (slot.HasTarget())
                {
                    allEnemiesDead = false;
                    break;
                }
            }

            if (allEnemiesDead)
            {
                state = TurnState.Victory;
                result.enabled = true;
                result.showVictory();
                yield break;
            }
        }
        
        yield return StartCoroutine(EnemyTurn());
    }

    private BattleSlot GetAliveEnemy()
    {
        foreach (BattleSlot slot in enemySlots)
        {
            if (slot.HasTarget())
                return slot;
        }

        return null;
    }

    private IEnumerator EnemyAttack()
    {
        BattleSlot enemySlot = GetAliveEnemy();

        if (enemySlot == null)
            yield break;

        CharacterStats enemy = enemySlot.occupant;
        CharacterAnimation enemyAnim =
            enemy.GetComponent<CharacterAnimation>();

        yield return StartCoroutine(
            enemyAnim.AttackRoutine(
                playerAnim,
                Vector3.right
            )
        );

        player.TakeDamage(enemy.attack);
    }
    
    private IEnumerator EnemyTurn()
    {
        state = TurnState.EnemyTurn;

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(EnemyAttack());

        yield return new WaitForSeconds(1f);

        if (player.IsDead())
        {
            state = TurnState.Defeat;
            result.enabled = true;
            result.showDefeat();
            yield break;
        }

        state = TurnState.PlayerTurn;
    }

    public void EnterTargetSelection()
    {
        selectingTarget = true;

        foreach (BattleSlot slot in enemySlots)
        {
            if (slot.HasTarget())
            {
                slot.Highlight();
            }
        }
    }

    public void HitTargetSelection(BattleSlot targetSlot)
    {
        if (!selectingTarget)
            return;

        selectingTarget = false;

        foreach (BattleSlot slot in enemySlots)
        {
            slot.UnHighlight();
        }

        StartCoroutine(PlayerAttack(targetSlot));
    }

    private void SpawnPlayer()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {
            if (!playerSlots[i].isOccupied)
            {
                GameObject obj = Instantiate(
                    BattleData.Instance.playerPrefab,
                    playerSlots[i].transform
                );

                obj.transform.localPosition = Vector3.zero;

                SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();

                sprite.sortingLayerName = "Player";
                sprite.sortingOrder = 0;

                CharacterAnimation anim =
                    obj.GetComponent<CharacterAnimation>();

                anim.FaceRight();

                CharacterStats stats =
                    obj.GetComponent<CharacterStats>();

                PlayerController controller = obj.GetComponent<PlayerController>();

                controller.enabled = false;

                playerSlots[i].SetOccupant(stats);

                player = stats;
                playerAnim = anim;

                break;
            }
        }
    }
    
    private void SpawnEnemies()
    {
        foreach (GameObject enemyPrefab in BattleData.Instance.enemyPrefabs)
        {
            BattleSlot emptySlot = null;

            foreach (BattleSlot slot in enemySlots)
            {
                if (!slot.isOccupied)
                {
                    emptySlot = slot;
                    break;
                }
            }

            if (emptySlot == null)
                break;

            GameObject obj = Instantiate(
                enemyPrefab,
                emptySlot.transform
            );

            obj.transform.localPosition = Vector3.zero;

            SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();

            sprite.flipX = true;
            sprite.sortingLayerName = "NPC (Enemy)";
            sprite.sortingOrder = 0;

            CharacterAnimation anim =
                obj.GetComponent<CharacterAnimation>();

            CharacterStats stats =
                obj.GetComponent<CharacterStats>();

            emptySlot.SetOccupant(stats);
        }
    }
}
