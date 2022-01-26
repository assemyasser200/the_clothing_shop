using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private GameObject dialogueBoxContainer;
    [SerializeField] private DialogueBoxController dialogueBoxPrefab;
    [SerializeField] private List<Dialogue> dialogues;

    private GameObject activeDialougeBox;
    private Queue<Sentence> sentences;
    private Dialogue dialogue;
    private Sentence sentence;

    private void StartDialogue(Dialogue newDialogue)
    {
        dialogue = newDialogue;
        sentences = new Queue<Sentence>();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        RemoveDialogueBox();

        if (sentences.Count > 0)
        {
            sentence = sentences.Dequeue();

            activeDialougeBox = Instantiate(dialogueBoxPrefab.gameObject) as GameObject;
            activeDialougeBox.transform.SetParent(dialogueBoxContainer.transform, false);
            activeDialougeBox.GetComponent<DialogueBoxController>().Initialize(sentence.speaker.name, sentence.content, sentence.speaker.GetStateSprite(sentence.emotion));
        }
    }

    public void TriggerDialogue(string key)
    {
        Dialogue triggeredDialogue = dialogues.Find(sceneDialogue => sceneDialogue.id.Equals(key));

        if (triggeredDialogue != null)
            StartDialogue(triggeredDialogue);
    }

    public void RemoveDialogueBox()
    {
        if (IsDialogueBoxActive())
        {
            Destroy(activeDialougeBox);
        }
    }

    public bool IsDialogueBoxActive()
    {
        return activeDialougeBox != null;
    }
}
