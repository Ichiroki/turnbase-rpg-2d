using System.Collections;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private SpriteRenderer sprite;

    public void FaceLeft()
    {
        sprite.flipX = true;
    }

    public void FaceRight()
    {
        sprite.flipX = false;
    }

    public void PlayAttack()
    {
        animator.SetBool("is_attack", true);
    }

    public void PlayHit()
    {
        StartCoroutine(FlashRed());
    }

    public void PlayDeath()
    {
        animator.SetBool("is_dead", true);
    }

    public void StopAttack()
    {
        animator.SetBool("is_attack", false);
    }

    public IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                6f * Time.deltaTime
            );

            yield return null;
        }
    }
    
    public IEnumerator AttackRoutine(CharacterAnimation target, Vector3 offset)
    {
        Vector3 startPosition = transform.position;

        Vector3 attackPosition =
            target.transform.position + offset;

        yield return MoveTo(attackPosition);

        PlayAttack();

        yield return new WaitForSeconds(0.2f);

        target.PlayHit();

        yield return MoveTo(startPosition);

        StopAttack();
    }

    public IEnumerator FlashRed()
    {
        Color originalColor = sprite.color;

        for(int i = 0; i < 3; i++) 
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.06f);

            sprite.color = originalColor;
            yield return new WaitForSeconds(0.06f);
        }
    }
}