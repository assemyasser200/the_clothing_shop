using UnityEngine;

[System.Serializable]
public class Sentence
{
    public Speaker speaker;
    public Emotion emotion;
    [TextArea] public string content;
}
