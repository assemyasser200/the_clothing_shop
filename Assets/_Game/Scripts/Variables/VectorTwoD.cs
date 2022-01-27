using UnityEngine;

[CreateAssetMenu(fileName = "Vector2 Variable", menuName = "Variables/Vector2 Variable")]
public class VectorTwoD : ScriptableObject
{
    private Vector2 vectorVar;

    public Vector2 VectorVar
    {
        set { vectorVar = value; }
        get { return vectorVar; }
    }
}
