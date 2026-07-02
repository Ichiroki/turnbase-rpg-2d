using UnityEngine;
using TMPro;

public class SpeechBubble : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text nameText;

    public void Say(string name, string text)
    {
        Show();
        SetText(name, text);
    }

    public void SetText(string name, string text)
    {
        nameText.text = name;
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
