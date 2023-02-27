using System;
using UnityEngine;

namespace BattleSystem
{
    public class ActionStateManager : MonoBehaviour
    {
        [SerializeField] private ActionState state = ActionState.Default;

        [SerializeField] private GameObject actionOverview;
        [SerializeField] private GameObject moveSelection;
        [SerializeField] private GameObject switchSelection;

        private void Update()
        {
            switch (state)
            {
                case ActionState.Attack:
                    ActivateAttackView();
                    break;
                case ActionState.Switch:
                    ActivateSwitchView();
                    break;
                case ActionState.Default:
                default:
                    ActivateDefaultView();
                    break;
            }
        }

        private void ActivateAttackView()
        {
            actionOverview.SetActive(false);
            moveSelection.SetActive(true);
            switchSelection.SetActive(false);
        }

        private void ActivateSwitchView()
        {
            actionOverview.SetActive(false);
            moveSelection.SetActive(false);
            switchSelection.SetActive(true);
        }

        private void ActivateDefaultView()
        {
            actionOverview.SetActive(true);
            moveSelection.SetActive(false);
            switchSelection.SetActive(false);
        }

        public void SetAttackState() => state = ActionState.Attack;

        public void SetSwitchState() => state = ActionState.Switch;

        public void SetDefaultState() => state = ActionState.Default;
    }

    public enum ActionState
    {
        Default,
        Attack,
        Switch
    }
}