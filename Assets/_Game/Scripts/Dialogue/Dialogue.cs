using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Clothing Shop/Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string id;
    public List<Sentence> sentences;
    public bool isSkippable = true;
}
