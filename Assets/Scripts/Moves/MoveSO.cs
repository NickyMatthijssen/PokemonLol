using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Contact
{
    Physical,
    Special,
    Status
}

[CreateAssetMenu(fileName = "MoveSO", menuName = "Pokemon/Move", order = 1)]
public class MoveSO : ScriptableObject
{
    public string moveName;
    public TypeSO type;
    public Contact contact;
    public int power;
    public int accuracy;
    public int speedPriority;
}
