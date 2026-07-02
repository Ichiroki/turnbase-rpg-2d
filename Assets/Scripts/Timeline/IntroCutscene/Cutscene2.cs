using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{
    public DialogueManager dialogue;

    public CharacterAnimation player;
    public CharacterAnimation slime1;
    public CharacterAnimation slime2;
    public CharacterAnimation morgan;
    
    public GameObject playerBattlePrefab;
    public GameObject slimeBattlePrefab;

    public void IntroLine1()
    {
        dialogue.ShowBubble(0, "You", "Hey, you stop!!");
    }

    public void IntroLine2()
    {
        dialogue.HideBubble(0);
    }

    public void IntroLine3()
    {
        dialogue.ShowBubble(1, "Stranger", "Ehhh, please help me sir, they tried to rob my goods");
        slime1.FaceLeft();
        slime2.FaceLeft();
    }

    public void IntroLine4()
    {
        dialogue.HideBubble(1);
        dialogue.ShowBubble(0, "You", "Don't worry, i will protect you, stay back");
    }

    public void IntroLine5()
    {
        BattleData.Instance.playerPrefab = playerBattlePrefab;

        BattleData.Instance.enemyPrefabs.Clear();

        BattleData.Instance.enemyPrefabs.Add(slimeBattlePrefab);
        BattleData.Instance.enemyPrefabs.Add(slimeBattlePrefab);

        GameProgress.Instance.forestIntroQuest = GameProgress.QuestState.Finished;

        GameProgress.Instance.playerSpawnPosition = new Vector3(
            12.9f, -0.5f, 0f
        );

        SceneManager.LoadScene("BattleScene");
    }
}