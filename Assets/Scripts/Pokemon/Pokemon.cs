using System;
using UnityEngine;

[Serializable]
public class Pokemon
{
    [Header("Base pokemon information")]
    public PokemonSO Species;
    [Range(1, 100)]
    public int level = 100;
    public string nickname;
    public float currentHp;

    [Header("Stats")]
    public int hp;
    public int attack;
    public int defence;
    public int specialAttack;
    public int specialDefence;
    public int speed;

    [Header("Individual Values")]
    public int hpIv = 31;
    public int attackIv = 31;
    public int defenceIv = 31;
    public int specialAttackIv = 31;
    public int specialDefenceIv = 31;
    public int speedIv = 31;
    
    [Header("Effort Values")]
    public int hpEv = 31;
    public int attackEv = 31;
    public int defenceEv = 31;
    public int specialAttackEv = 31;
    public int specialDefenceEv = 31;
    public int speedEv = 31;

    [Header("Current moves")]
    public MoveSO[] moves;

    public void Init()
    {
        nickname = Species.Name;

        SetupStats();
    }

    private void SetupStats()
    {
        hp = CalculateHp();
        currentHp = hp;
        attack = CalculateStat(Species.Attack, attackIv, attackEv);
        defence = CalculateStat(Species.Defence, defenceIv, defenceEv);
        specialDefence = CalculateStat(Species.SpecialDefence, specialDefenceIv, specialDefenceEv);
        specialAttack = CalculateStat(Species.SpecialAttack, specialAttackIv, specialAttackEv);
        speed = CalculateStat(Species.Speed, speedIv, speedEv);
    }

    private int CalculateHp()
    {
        // HP: floor(0.01 x (2 x Base + IV + floor(0.25 x EV)) x Level) + Level + 10
        return Mathf.FloorToInt(0.01f * (2 * Species.Health + hpIv + Mathf.Floor(0.25f * hpEv)) * level) + level + 10;
    }

    private int CalculateStat(int baseStat, int iv, int ev)
    {
        // Rest:  (floor(0.01 x (2 x Base + IV + floor(0.25 x EV)) x Level) + 5) x Nature
        // Ignoring nature for now.
        return Mathf.FloorToInt(0.01f * (2 * baseStat + iv + Mathf.Floor(0.025f * ev)) * level) + 5;
    }
}
