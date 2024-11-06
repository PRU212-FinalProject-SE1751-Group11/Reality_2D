using System.Collections.Generic;
using UnityEngine;
public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] private List<Dialog> dialogues;

    public void Interact()
    {
        Dialog appropriateDialog = GetDialogForCurrentCondition();
        if (appropriateDialog != null)
        {
            ApplyTriggers(appropriateDialog.Triggers);
            string sceneToLoad = (appropriateDialog.Condition == DialogCondition.DoneLighter) ? "00.1" : null;
            DialogueManager.Instance.ShowDialog(appropriateDialog, sceneToLoad);
        }
    }

    private Dialog GetDialogForCurrentCondition()
    {
        foreach (Dialog dialog in dialogues)
        {
            if (GameState.Instance.FirstMeeting && dialog.Condition == DialogCondition.FirstMeeting)
            {
                return dialog;
            }
            else if (GameState.Instance.OnKeyWest && dialog.Condition == DialogCondition.OnKeyWest)
            {
                return dialog;
            }
            else if (GameState.Instance.GotKeyWest && dialog.Condition == DialogCondition.GotKeyWest)
            {
                return dialog;
            }
            else if (GameState.Instance.DoneKeyWest && dialog.Condition == DialogCondition.DoneKeyWest)
            {
                return dialog;
            }
            else if (GameState.Instance.DoneLighter && dialog.Condition == DialogCondition.DoneLighter)
            {
                return dialog;
            }
            else if (GameState.Instance.OpenMind && dialog.Condition == DialogCondition.OpenMind)
            {
                return dialog;
            }
            else if (GameState.Instance.OpenSecret && dialog.Condition == DialogCondition.OpenSecret)
            {
                return dialog;
            }
        }
        return dialogues.Find(d => d.Condition == DialogCondition.General);
    }

    private void ApplyTriggers(List<GameStateTrigger> triggers)
    {
        foreach (var trigger in triggers)
        {
            GameState.Instance.SetState(trigger.condition, trigger.value);
        }
    }
}