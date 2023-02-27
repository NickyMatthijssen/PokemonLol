using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class PokemonSelector : MonoBehaviour
    {
        [SerializeField] private BattleSystem2.BattleSystem _battleSystem;
        [SerializeField] private Button _buttonPrefab;

        private void Start()
        {
            foreach (var pokemon in _battleSystem.PlayerParty.PokemonList)
            {
                var btn = Instantiate(_buttonPrefab, transform);
                var text = btn.GetComponentInChildren<TMP_Text>();
                text.text = pokemon.Nickname;
                // btn.onClick.AddListener(() => _battleSystem);
            }
        }
    }
}