using UnityEngine;

[CreateAssetMenu(fileName = "Boolean Variable", menuName = "Variables/Boolean Variable")]
public class BooleanVariable : ScriptableObject
{
    private bool boolVar;

    public bool BoolVar
    {
        set { boolVar = value; }
        get { return boolVar; }
    }
}
