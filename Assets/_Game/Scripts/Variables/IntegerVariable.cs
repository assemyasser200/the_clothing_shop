using UnityEngine;

[CreateAssetMenu(fileName = "Integer Variable", menuName = "Variables/Integer Variable")]
public class IntegerVariable : ScriptableObject
{
    private int intVar;

    public int IntVar
    {
        set { intVar = value; }
        get { return intVar; }
    }
}