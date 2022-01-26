using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Emotion
{
    Normal,
    Happy,
    Sad,
    Angry
}

[System.Serializable]
public struct SpeakerState
{
    public Emotion emotion;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "New Speaker", menuName = "Clothing Shop/Dialogue System/Speaker")]
public class Speaker : ScriptableObject
{
    public new string name;
    public List<SpeakerState> states;

    public Sprite GetStateSprite(Emotion currentEmotion)
    {
        return states.Find(state => state.emotion == currentEmotion).sprite;
    }
}
