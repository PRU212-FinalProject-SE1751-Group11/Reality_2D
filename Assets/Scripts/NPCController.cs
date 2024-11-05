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
            // Check if the quest is completed and show the specific dialog for that condition
            if (GameState.Instance.OpenMind && dialog.Condition == DialogCondition.OpenMind)
            {
                return dialog;
            }
            // If the player has met the NPC but hasn't completed the quest, show the general dialog
            else if (!GameState.Instance.OpenMind && dialog.Condition == DialogCondition.General)
            {
                return dialog;
            }
        }
        return dialogues.Find(d => d.Condition == DialogCondition.General);
    }
}