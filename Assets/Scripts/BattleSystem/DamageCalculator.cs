using System.Linq;
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
            var fullDamage = Mathf.FloorToInt(baseDamage * _move.Power * GetAttack() / GetDefence()) / 50 + 2;

            var modifiedDamage = fullDamage * GetTargets() * GetWeather() * GetBadge() * GetCritical() * GetRandom() *
                                 GetStab() * GetType() * GetBurn() * GetOther();

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
            // var weather = _battleSystem.weather;

            // if (weather == Weather.Rain && _move.type == "water" || weather == Weather.Sunny && _move.type == "fire")
            // {
            //     return 1.5f;
            // }
            //
            // if (weather == Weather.Rain && _move.type == "fire" || weather == Weather.Sunny && _move.type == "water")
            // {
            //     return 0.5f;
            // }

            return 1;
        }

        /// <summary>
        /// The badge mechanic is only used in gen 2 and would add a modifier to 1.25x for a type of which the player had a badge.
        /// </summary>
        /// <returns>int</returns>
        private int GetBadge() => 1;


        private float GetCritical()
        {
            // TODO:: Someday implement the correct critical hit method;

            if (Random.Range(0, 100) <= 6.25f)
            {
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

            // if (_attacking.Pokemon.Species.types.Any(t => t == _move.Type))
            // {
            //     return 1.5f;
            // }

            return 1;
        }

        private int GetType() => 1;

        private int GetBurn()
        {
            // TODO:: Check if ability is guts or if the move used is Facade to skip check and return 1 directly.
            
            // TODO:: Add status to unit to check if they are burned. If burned return 0.5 else 1.
            return 1;
        }

        private int GetOther()
        {
            // TODO:: Add other checks when items, abilities, etc. are added in.
            
            return 1;
        }
    }
}