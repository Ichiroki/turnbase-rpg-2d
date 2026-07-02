using UnityEngine;

public class CutsceneManager : MonoBehaviour
{

    public GameObject slime1;
    public GameObject slime2;

    private void Start()
    {
        if(GameProgress.Instance.forestIntroQuest == GameProgress.QuestState.Finished)
        {
            slime1.SetActive(false);
            slime2.SetActive(false);
        }
    }
}
