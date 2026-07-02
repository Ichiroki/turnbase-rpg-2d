using UnityEngine;

public class GameProgress : Singleton<GameProgress>
{
    public enum QuestState
    {
        NotStarted,
        InProgress,
        Finished
    }

    public QuestState forestIntroQuest;

    public Vector3 playerSpawnPosition;
}
