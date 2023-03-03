using BattleSystem2;
using TMPro;
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
            if (battleSystem?.CurrentUnit is null || unit?.Pokemon == battleSystem?.CurrentUnit?.Pokemon) return;
            
            Debug.Log(battleSystem.CurrentUnit.Pokemon);

            var buttons = gameObject.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
            
            unit = battleSystem.CurrentUnit;
            for (int i = 0; i < unit.Pokemon.Moves.Length; i++)
            {
                var move = unit.Pokemon.Moves[i];
                var button = Instantiate(moveButtonPrefab, transform); ;
                var text = button.GetComponentInChildren<TMP_Text>();
                text.text = move.MoveName;
                button.onClick.AddListener(() => unit.SelectMove(move));
                var rect = button.GetComponent<RectTransform>();
                rect.transform.localPosition = Vector3.down * (rect.rect.height + 10) * i;
            }
        }
    }
}