using System;
using System.Linq;
using Monsters;
using UnityEngine;

namespace BattleSystem
{
    [Serializable]
    public class Party
    {
        [SerializeField] private Pokemon[] pokemonList;
        public Pokemon[] PokemonList => pokemonList;

        public Pokemon[] AvailablePokemon => PokemonList.Where(p => p.CurrentHitPoints > 0).ToArray();

        public bool HasAvailablePokemon => AvailablePokemon.Length > 0;

        public bool IsWhitedOut => !HasAvailablePokemon;
    }
}