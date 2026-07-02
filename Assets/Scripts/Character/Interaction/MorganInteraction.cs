using UnityEngine;
using UnityEngine.Playables;

public class MorganController : MonoBehaviour
{
    public InteractionTrigger trigger;

    public PlayableDirector cutscene3;

    void Start()
    {
        trigger.onInteract += StartCutscene;
    }

    void StartCutscene()
    {
        trigger.enabled = false;

        cutscene3.Play();
    }
}
