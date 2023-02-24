using UnityEngine;

[CreateAssetMenu(fileName = "TypeSO", menuName = "Pokemon/Type", order = 1)]
public class TypeSO : ScriptableObject
{
    public string typeName;
    public TypeSO[] effectiveness;
    public TypeSO[] weaknesses;
    public TypeSO[] immunities;
}
