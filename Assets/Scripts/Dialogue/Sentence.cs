using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sentence", menuName = "Clothing Shop/Dialogue/Sentence")]
public class Sentence : ScriptableObject
{
    public Speaker speaker;
    [TextArea] public string content;
}
