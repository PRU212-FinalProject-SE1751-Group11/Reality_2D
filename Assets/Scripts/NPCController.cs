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
            DialogueManager.Instance.ShowDialog(appropriateDialog);
        }
    }

    private Dialog GetDialogForCurrentCondition()
    {
        foreach (Dialog dialog in dialogues)
        {
            if ((dialog.Condition == DialogCondition.General))
            //(GameState.Instance.hasMetNPC && !GameState.Instance.completedQuest1 && dialog.Condition == DialogCondition.FirstMeeting) ||
            //(!GameState.Instance.hasMetNPC && dialog.Condition == DialogCondition.General))
            {
                return dialog;
            }
        }

        return dialogues.Find(d => d.Condition == DialogCondition.General);
    }
}