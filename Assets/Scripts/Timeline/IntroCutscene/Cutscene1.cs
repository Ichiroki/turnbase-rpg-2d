using UnityEngine;
using UnityEngine.Playables;

public class Cutscene1 : MonoBehaviour
{
    public DialogueManager dialogue;
    public PlayableDirector director;

    private void Start()
    {
        if(GameProgress.Instance.forestIntroQuest == GameProgress.QuestState.NotStarted)
        {
            director.Play();
        }
    }


    public void IntroLine1()
    {
        dialogue.ShowBubble(0, "I got only few money and lunch.");
    }

    public void IntroLine2()
    {
        dialogue.ShowBubble(0, "Can i reach the town with only this ?");
    }

    public void IntroLine3()
    {
        dialogue.HideBubble(0);
        dialogue.ShowBubble(2, "ARRGGGHHH!!!, Help me");
    }

    public void IntroLine4()
    {
        dialogue.HideBubble(2);
        dialogue.ShowBubble(0, "Is someone needs help ? i gotta help him");
    }

    public void IntroLine5()
    {
        dialogue.HideBubble(0);
    }
}
