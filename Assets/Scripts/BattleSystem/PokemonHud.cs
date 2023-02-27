using Monsters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class PokemonHud : MonoBehaviour
    {
        [SerializeField] private Pokemon pokemon;
        [SerializeField] private TMP_Text pokemonName;
        [SerializeField] private TMP_Text pokemonLevel;
        [SerializeField] private Slider pokemonHitPoints;

        public void Initialize(Pokemon pokemon)
        {
            this.pokemon = pokemon;
        }
        
        public void Update()
        {
            if (pokemon == null) return;

            pokemonName.text = pokemon.Nickname;
            pokemonLevel.text = pokemon.Level.ToString();
            pokemonHitPoints.value = (float) pokemon.CurrentHitPoints / pokemon.HitPoints;
        }
    }
}