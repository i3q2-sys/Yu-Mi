using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
public class DialogueTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        DialogueBuble dialogue = playerData as DialogueBuble;
        string currentText = "";
        Vector2 currentPosition = new Vector2(0, 0);
        bool facingLeft = true;
        float currentAlpha = 0f;

        if (!dialogue) { return; }

        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0f)
            {
                ScriptPlayable<DialogueBehaviour> inputPlayable = (ScriptPlayable<DialogueBehaviour>)playable.GetInput(i);
                double duration = inputPlayable.GetDuration() - 1;
                double time = inputPlayable.GetTime();
                DialogueBehaviour input = inputPlayable.GetBehaviour();

                string text = input.DialogueText;
                int lenght = text.Length;
                int index;
                if (time < duration) index = (int)((time * lenght) / duration) + 1;
                else index = lenght;

                currentText = text.Substring(0, index);
                currentPosition = input.DialoguePosition;
                facingLeft = input.FacingLeft;
                currentAlpha = inputWeight;

            }
        }


        dialogue.SetText(currentText);
        dialogue.SetPosition(currentPosition);
        dialogue.SetTransparency(currentAlpha);
        dialogue.SetFacingLeft(facingLeft);
    }
}