using Monsters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class PokemonSelector : MonoBehaviour
    {
        [SerializeField] private BattleSystem2.BattleSystem _battleSystem;
        [SerializeField] private Button _buttonPrefab;

        [SerializeField] private Pokemon pokemon;

        private void Update()
        {
            if (_battleSystem.CurrentUnit is null || pokemon == _battleSystem.CurrentUnit?.Pokemon)
            {
                return;
            }

            pokemon = _battleSystem.CurrentUnit.Pokemon;
            
            var buttons = gameObject.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
            
            for (int i = 0; i < _battleSystem.PlayerParty.PokemonList.Length; i++)
            {
                var pokemon = _battleSystem.PlayerParty.PokemonList[i];
                var btn = Instantiate(_buttonPrefab, transform);
                var text = btn.GetComponentInChildren<TMP_Text>();
                text.text = pokemon.Nickname;
                btn.onClick.AddListener(() => _battleSystem.SwitchPokemon(pokemon));
                var rect = btn.GetComponent<RectTransform>();
                rect.transform.localPosition = Vector3.down * (rect.rect.height + 10) * i;
            }
        }
    }
}