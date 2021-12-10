using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueClip : PlayableAsset
{
    public string dialogueText;
    public Vector2 dialoguePosition;
    public bool facingLeft;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogueBehaviour>.Create(graph);
        DialogueBehaviour dialoguebehaviour = playable.GetBehaviour();
        dialoguebehaviour.DialogueText = dialogueText;
        dialoguebehaviour.DialoguePosition = dialoguePosition;
        dialoguebehaviour.FacingLeft = facingLeft;

        return playable;
    }
}