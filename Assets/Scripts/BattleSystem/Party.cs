using System;
using Monsters;
using UnityEngine;

namespace BattleSystem
{
    [Serializable]
    public class Party
    {
        [SerializeField] private Pokemon[] pokemonList;
        public Pokemon[] PokemonList => pokemonList;

        public Party()
        {
            pokemonList = new Pokemon[6];
        }
    }
}