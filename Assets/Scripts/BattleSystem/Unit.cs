using System.Collections.Generic;
using JetBrains.Annotations;
using Monsters;
using Moves;
using UnityEngine;

namespace BattleSystem2
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Pokemon pokemon;
        public Pokemon Pokemon => pokemon;
        
        [SerializeField] private NonVolatileStatus status;
        public NonVolatileStatus Status => status;

        [SerializeField] private VolatileStatus[] volatileStatuesList;
        public VolatileStatus[] VolatileStatusList => volatileStatuesList;

        [SerializeField] private VolatileBattleStatus[] volatileBattleStatusList;
        public VolatileBattleStatus[] VolatileBattleStatusList => volatileBattleStatusList;

        [SerializeField] private bool belongsToPlayer;
        public bool BelongsToPlayer => belongsToPlayer;

        [SerializeField] [CanBeNull] private MoveSO selectedMove;
        [CanBeNull] public MoveSO SelectedMoved => selectedMove;

        [SerializeField] [CanBeNull] private Unit[] selectedTargets;
        [CanBeNull] public Unit[] SelectedTargets => selectedTargets;
        
        [CanBeNull] [field:SerializeField] public MoveSO PreviousMove { get; set; }

        public IList<Unit> Targets { get; } = new List<Unit>();

        public void Initialize(Pokemon pokemon, bool belongsToPlayer)
        {
            this.pokemon = pokemon;
            this.belongsToPlayer = belongsToPlayer;

            Instantiate(pokemon.Species.Model, transform);
        }

        public void SelectMove(MoveSO move) => selectedMove = move;

        public void SelectTarget(Unit[] units) => selectedTargets = units;

        public void ClearMove() => selectedMove = null;
    }
}