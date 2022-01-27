using UnityEngine;

/// <summary>
/// A tracker for a string variable
/// </summary>
[CreateAssetMenu(fileName = "StringVariable", menuName = "Variables/String Variable")]
public class StringVariable : ScriptableObject
{
    [SerializeField] private string stringValue;

    public string StringValue
    {
        get{ return stringValue; }
        set { stringValue = value; }
    }
}
