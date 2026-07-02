using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text dialogueText;

    public void Say(string text)
    {
        Show();
        SetText(text);
    }

    public void SetText(string text)
    {
        dialogueText.text = text;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
