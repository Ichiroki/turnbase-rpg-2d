using UnityEngine;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public List<SpeechBubble> bubbles;

    public void ShowBubble(int index, string name, string text)
    {
        bubbles[index].Say(name, text);
    }

    public void HideBubble(int index)
    {
        bubbles[index].Hide();
    }
}
