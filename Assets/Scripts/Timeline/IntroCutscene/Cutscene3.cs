using UnityEngine;

public class Cutscene3 : MonoBehaviour
{
    public DialogueManager dialogue;

    public GameObject toBeContinued;

    public void IntroLine1()
    {
        dialogue.ShowBubble(0, "You", "Are you okay sir ?");
    }

    public void IntroLine2()
    {
        dialogue.HideBubble(0);
        dialogue.ShowBubble(1, "Stranger", "Yes, i'm okay, thank you for your aid sir.");
    }

    public void IntroLine3()
    {
        dialogue.HideBubble(1);
        dialogue.ShowBubble(0, "You", "I don't know why there are monsters in the forest");
    }

    public void IntroLine4()
    {
        dialogue.HideBubble(0);
        dialogue.ShowBubble(1, "Stranger", "Because the new devil king was been raised");
    }

    public void IntroLine5()
    {
        dialogue.ShowBubble(1, "Stranger", "We should go, before the others came to find us");
    }

    public void IntroLine6()
    {
        dialogue.HideBubble(1);
        dialogue.ShowBubble(0, "You", "Lead the way sir");

        toBeContinued.SetActive(true);
    }
}
