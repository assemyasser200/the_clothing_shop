using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using I2.Loc;
using TMPro;

public class DialogueBoxController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float printingDelay;
    [SerializeField] private bool stopWriting;
    [SerializeField] private bool finishWriting;

    [Header("UI")]
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button boxButton;

    private string fullText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
        {
            if (finishWriting)
            {
                DialogueManager.Instance.DisplayNextSentence();
            }
            else
            {
                StopSentence();
                ShowWholeSentence(fullText);
            }
        }
    }

    public void Initialize(string sentence, string characterName = "", Sprite characterSprite = null)
    {
        if (characterSprite == null)
        {
            characterImage.gameObject.SetActive(false);
        }
        else
        {
            characterImage.sprite = characterSprite;
        }

        if (string.IsNullOrEmpty(characterName))
        {
            characterNameText.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            characterNameText.GetComponent<Localize>().SetTerm("Speakers/" + characterName);
        }

        dialogueText.GetComponent<Localize>().SetTerm("Dialogues/" + sentence);
        fullText = dialogueText.text;

        boxButton.onClick.AddListener(() =>
        {
            if (finishWriting)
            {
                DialogueManager.Instance.DisplayNextSentence();
            }
            else
            {
                StopSentence();
                ShowWholeSentence(fullText);
            }
        });

        StopCoroutine(nameof(TypeSentence));
        StartCoroutine(TypeSentence(dialogueText.text));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        stopWriting = false;

        if (sentence != null)
        {
            dialogueText.text = "";

            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(printingDelay);

                if (stopWriting)
                {
                    break;
                }
            }

            finishWriting = true;
        }
    }

    private void StopSentence()
    {
        stopWriting = true;
        StopCoroutine("TypeSentence");
    }

    private void ShowWholeSentence(string sentence)
    {
        dialogueText.text = sentence;
        finishWriting = true;
    }
}
