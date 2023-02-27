using Moves;
using UnityEngine;

namespace BattleSystem2
{
    public class DamageCalculator
    {
        private Unit _attacking;
        private Unit _target;
        private BattleSystem _battleSystem;
        private Moves.MoveSO _move;

        private bool _isCritical;
        public bool IsCritical => _isCritical;
        
        public DamageCalculator(Moves.MoveSO move, Unit attacking, Unit target, BattleSystem battleSystem)
        {
            _move = move;
            _attacking = attacking;
            _target = target;
            _battleSystem = battleSystem;
        }

        public int Calculate()
        {
            var baseDamage = Mathf.FloorToInt(2 * _attacking.Pokemon.Level / 5 + 2);
            var fullDamage = Mathf.FloorToInt((float) baseDamage * _move.Power * GetAttack() / GetDefence()) / 50 + 2;

            var modifiedDamage = fullDamage * GetTargets() * GetWeather() * GetBadge() * GetCritical() * GetRandom() *
                                 GetStab() * GetType(_target.Pokemon.Species.PrimaryType) * GetType(_target.Pokemon.Species.SecondaryType) * GetBurn() * GetOther();

            return Mathf.FloorToInt(modifiedDamage);
        }
        
        /// <summary>
        /// Get the attack stat or special attack stat of the attacking pokemon based on the move contact.
        /// </summary>
        /// <returns>int</returns>
        private int GetAttack()
        {
            return _move.Category == MoveCategory.Physical 
                ? _attacking.Pokemon.Attack 
                : _attacking.Pokemon.SpecialAttack;
        }

        private int GetDefence()
        {
            return _move.Category == MoveCategory.Physical 
                ? _target.Pokemon.Defence 
                : _target.Pokemon.SpecialDefence;
        }

        private int GetTargets()
        {
            // TODO:: Should be expanded upon if double battles will be implemented.
            
            return 1;
        }

        private float GetWeather()
        {
            var weather = _battleSystem.Weather;

            if (weather == Weather.Rain && _move.Type == Type.Water || weather == Weather.Sunny && _move.Type == Type.Fire)
            {
                return 1.5f;
            }
            
            if (weather == Weather.Rain && _move.Type == Type.Fire || weather == Weather.Sunny && _move.Type == Type.Water)
            {
                return 0.5f;
            }

            return 1;
        }

        /// <summary>
        /// The badge mechanic is only used in gen 2 and would add a modifier to 1.25x for a type of which the player had a badge.
        /// </summary>
        /// <returns>int</returns>
        private int GetBadge() => 1;


        private float GetCritical()
        {
            if (Random.Range(0, 100) <= 6.25f)
            {
                _isCritical = true;
                return 1.5f;
            }
            
            return 1;
        }

        /// <summary>
        /// Returns a random chaotic value to determine the RNG value of the damage.
        /// </summary>
        /// <returns>float</returns>
        private float GetRandom() => Random.Range(0.85f, 1);

        private float GetStab()
        {
            // TODO:: Someday add check if attacker has adaptability to return 2.

            var species = _attacking.Pokemon.Species;
            if (species.PrimaryType == _move.Type || species.SecondaryType == _move.Type)
            {
                return 1.5f;
            }

            return 1;
        }

        private float GetType(Type type)
        {
            var map = new TypeMap();
            return map.CheckMultiplier(type, _move.Type);
        }

        private float GetBurn()
        {
            // TODO:: Check if ability is guts or if the move used is Facade to skip check and return 1 directly.
            
            if (_attacking.Status == NonVolatileStatus.Burn && _move.Id != MoveKeys.Facade)
            {
                return 0.5f;
            }
            
            return 1;
        }

        private int GetOther()
        {
            // TODO:: Add other checks when items, abilities, etc. are added in.
            
            
            return 1;
        }
    }
}