using BattleSystem2;
using UnityEngine;

namespace BattleSystem
{
    public class UiStateManager : MonoBehaviour
    {
        [SerializeField] private BattleSystem2.BattleSystem battleSystem;
        
        [SerializeField] private GameObject dialogueBox;
        [SerializeField] private GameObject actionSelection;

        void Update()
        {
            switch (battleSystem.State)
            {
                case BattleState.Initializing:
                    HideUI();
                    break;
                case BattleState.Waiting:
                case BattleState.Combat:
                case BattleState.Finished:
                    ActivateDialogueBox();
                    break;
                case BattleState.MoveSelection:
                default:
                    ActivateActionSelection();
                    break;
            }
        }

        void HideUI()
        {
            actionSelection.SetActive(false);
            dialogueBox.SetActive(false);
        }

        void ActivateActionSelection()
        {
            actionSelection.SetActive(true);
            dialogueBox.SetActive(false);
        }

        void ActivateDialogueBox()
        {
            actionSelection.SetActive(false);
            dialogueBox.SetActive(true);
        }
    }
}
