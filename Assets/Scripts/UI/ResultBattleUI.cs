using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultBattleUI : MonoBehaviour
{
    public TMP_Text resultText;

    public void showVictory() 
    {
        gameObject.SetActive(true);
        resultText.text = "Victory";
    }

    public void showDefeat() 
    {
        gameObject.SetActive(true);
        resultText.text = "Defeat";
    }

    public void Cutscene2Continue()
    {
        GameProgress.Instance.forestIntroQuest = GameProgress.QuestState.Finished;

        SceneManager.LoadScene("World");
    }
}
