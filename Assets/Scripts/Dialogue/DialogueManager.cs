using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private List<Dialogue> dialogues;

    public void TriggerDialogue(string dialougeId)
    {

    }
}
