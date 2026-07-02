using UnityEngine;
using UnityEngine.Playables;

public class TimelineTrigger : MonoBehaviour
{
    public PlayableDirector timeline;

    public GameProgress.QuestState requiredState;
    public bool checkQuestFinished;

    private bool played = false;

    private void Start()
    {
        if(checkQuestFinished)
        {
            played = GameProgress.Instance.forestIntroQuest == GameProgress.QuestState.Finished;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(played) return;

        if(!other.CompareTag("Player")) return;

        played = true;
        timeline.Play();
    }
}
