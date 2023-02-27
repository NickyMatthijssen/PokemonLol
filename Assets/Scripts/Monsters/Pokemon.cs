using System;
using BattleSystem2;
using Moves;
using UnityEngine;

namespace Monsters
{
    [Serializable]
    public class Pokemon
    {
        [Header("Common")]
        [SerializeField] private PokemonSO species;
        public PokemonSO Species => species;

        [SerializeField] private string nickname;
        public string Nickname => String.IsNullOrEmpty(nickname) ? Species.PokemonName : nickname;

        [SerializeField] private Nature nature;
        public Nature Nature => nature;

        [Header("Stats")]
        [SerializeField] private int level;
        public int Level => level;

        private int? _currentHitPoints;
        public int CurrentHitPoints
        {
            get
            {
                if (_currentHitPoints == null)
                {
                    _currentHitPoints = HitPoints;
                }

                return (int) _currentHitPoints;
            }
        }

        public int HitPoints => Mathf.FloorToInt(Mathf.Floor(0.01f * (2 * species.HitPoints + ivHitPoints + Mathf.Floor(0.25f * evHitPoints)) * Level) + Level + 10);
        
        public int Attack =>
            Mathf.FloorToInt((Mathf.Floor(0.01f * (2 * Species.Attack + ivAttack + Mathf.Floor(0.25f * evAttack)) * Level) + 5) * 1);
        
        public int Defence => Mathf.FloorToInt((Mathf.Floor(0.01f * (2 * Species.Defence + ivDefence + Mathf.Floor(0.25f * evDefence)) * Level) + 5) * 1);
        
        public int SpecialAttack => Mathf.FloorToInt((Mathf.Floor(0.01f * (2 * Species.SpecialAttack + ivSpecialAttack + Mathf.Floor(0.25f * evSpecialAttack)) * Level) + 5) * 1);
            
        public int SpecialDefence => Mathf.FloorToInt((Mathf.Floor(0.01f * (2 * Species.SpecialDefence + ivSpecialDefence + Mathf.Floor(0.25f * evSpecialDefence)) * Level) + 5) * 1);
            
        public int Speed => Mathf.FloorToInt((Mathf.Floor(0.01f * (2 * Species.Speed + ivSpeed + Mathf.Floor(0.25f * evSpeed)) * Level) + 5) * 1);
        
        [SerializeField] private MoveSO[] moves;
        public MoveSO[] Moves => moves;
        
        [Header("IV")]
        [SerializeField, Range(1,31)] private int ivHitPoints = 31;
        [SerializeField, Range(1,31)] private int ivAttack = 31;
        [SerializeField, Range(1,31)] private int ivDefence = 31;
        [SerializeField, Range(1,31)] private int ivSpecialAttack = 31;
        [SerializeField, Range(1,31)] private int ivSpecialDefence = 31;
        [SerializeField, Range(1,31)] private int ivSpeed = 31;
        
        [Header("EV")]
        [SerializeField, Range(0,255)] private int evHitPoints = 255;
        [SerializeField, Range(0,255)] private int evAttack = 255;
        [SerializeField, Range(0,255)] private int evDefence = 255;
        [SerializeField, Range(0,255)] private int evSpecialAttack = 255;
        [SerializeField, Range(0,255)] private int evSpecialDefence = 255;
        [SerializeField, Range(0, 255)] private int evSpeed = 255;

        public void TakeDamage(int damage) => _currentHitPoints = Mathf.Max(CurrentHitPoints - damage, 0);
    }
}