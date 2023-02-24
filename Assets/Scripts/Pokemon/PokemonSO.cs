using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PokemonSO", menuName = "Characters/Pokemon", order = 0)]
public class PokemonSO : ScriptableObject
{
    public string Name;

    public int Speed;
    public int Attack;
    public int Defence;
    public int SpecialAttack;
    public int SpecialDefence;
    public int Health;

    public GameObject Model;

    public TypeSO[] types;
}
