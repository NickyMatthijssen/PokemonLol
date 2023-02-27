using System;
using BattleSystem2;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class MoveSelector : MonoBehaviour
    {
        [SerializeField] private BattleSystem2.BattleSystem battleSystem;
        [SerializeField] private Button moveButtonPrefab;

        [SerializeField] private Unit unit;
        
        private void Update()
        {
            if (unit == battleSystem.CurrentUnit || battleSystem.CurrentUnit is null) return;

            var buttons = gameObject.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
            
            unit = battleSystem.CurrentUnit;
            foreach (var move in unit.Pokemon.Moves)
            {
                var button = Instantiate(moveButtonPrefab, transform); ;
                var text = button.GetComponentInChildren<Text>();
                text.text = move.MoveName;
                button.onClick.AddListener(() => unit.SelectMove(move));
            }
        }
    }
}