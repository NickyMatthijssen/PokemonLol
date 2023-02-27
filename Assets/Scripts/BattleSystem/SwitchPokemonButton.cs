using System;
using Monsters;
using TMPro;
using UnityEngine;

namespace BattleSystem
{
    public class SwitchPokemonButton : MonoBehaviour
    {
        private Pokemon _pokemon;

        [SerializeField] private TMP_Text text;
        // [SerializeField] private Image image;
        
        public void Initialize(Pokemon pokemon)
        {
            text.text = pokemon.Nickname;
        }
    }
}