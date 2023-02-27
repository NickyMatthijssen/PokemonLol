
using System;
using Moves;
using UnityEngine;
using Type = BattleSystem2.Type;

namespace Monsters
{
    [CreateAssetMenu(fileName = "PokemonSO", menuName = "Pokemon/Monster", order = 0)]
    public class PokemonSO : ScriptableObject
    {
        [SerializeField] private string pokemonName;
        public string PokemonName => pokemonName;

        [SerializeField] private int hitPoints;
        public int HitPoints => hitPoints;

        [SerializeField] private int attack;
        public int Attack => attack;

        [SerializeField] private int defence;
        public int Defence => defence;

        [SerializeField] private int specialAttack;
        public int SpecialAttack => specialAttack;

        [SerializeField] private int specialDefence;
        public int SpecialDefence => specialDefence;

        [SerializeField] private int speed;
        public int Speed => speed;

        [SerializeField] private LearnableMove[] learnableMoves;
        public LearnableMove[] LearnableMoves => learnableMoves;

        [SerializeField] private Type primaryType;
        public Type PrimaryType => primaryType;

        [SerializeField] private Type secondaryType;
        public Type SecondaryType => secondaryType;

        [SerializeField] private GameObject model;
        public GameObject Model => model;
    }

    [Serializable]
    public class LearnableMove
    {
        [SerializeField] private int level;
        public int Level => level;

        [SerializeField] private MoveSO move;
        public MoveSO Move => move;
    }
}