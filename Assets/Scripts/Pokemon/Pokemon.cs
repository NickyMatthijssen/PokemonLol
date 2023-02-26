using System;
using UnityEngine;

namespace Pokemon
{
    [Serializable]
    public class Pokemon
    {
        [Header("Common")]
        [SerializeField] private PokemonSO species;
        public PokemonSO Species => species;

        [SerializeField] private string nickname;
        public string Nickname => nickname;

        [Header("Stats")]
        [SerializeField] private int level;
        public int Level => level;

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
        
        [Header("IV")]
        [SerializeField, Range(1,31)] private int ivHitPoints;
        [SerializeField, Range(1,31)] private int ivAttack;
        [SerializeField, Range(1,31)] private int ivDefence;
        [SerializeField, Range(1,31)] private int ivSpecialAttack;
        [SerializeField, Range(1,31)] private int ivSpecialDefence;
        [SerializeField, Range(1,31)] private int ivSpeed;
        
        [Header("EV")]
        [SerializeField, Range(1,255)] private int evHitPoints;
        [SerializeField, Range(1,255)] private int evAttack;
        [SerializeField, Range(1,255)] private int evDefence;
        [SerializeField, Range(1,255)] private int evSpecialAttack;
        [SerializeField, Range(1,255)] private int evSpecialDefence;
        [SerializeField, Range(1,255)] private int evSpeed;

        public void Setup()
        {
            // Setup name.
            
            // Generate stats.
        }
    }
}