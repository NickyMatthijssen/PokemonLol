using System.Collections.Generic;
using BattleSystem;
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

        private PokemonHud _hud;
        private GameObject _model;

        public void Initialize(Pokemon pokemon, bool belongsToPlayer, PokemonHud hud, BattleSystem battleSystem)
        {
            this.belongsToPlayer = belongsToPlayer;
            _hud = hud;

            SetupPokemon(pokemon);
        }

        public void SetupPokemon([CanBeNull] Pokemon pokemon)
        {
            if (pokemon == null)
            {
                ClearPokemon();
                return;
            }
            
            _hud.Initialize(pokemon);
            this.pokemon = pokemon;

            if (_model == null)
            { 
                _model = Instantiate(pokemon.Species.Model, transform);
                _model.AddComponent<Rigidbody>();
                _model.AddComponent<CapsuleCollider>();
            }
            else
            {
                var oldModel = _model.GetComponentInChildren<Transform>();
                Destroy(oldModel.gameObject);
                _model = Instantiate(pokemon.Species.Model, transform);
            }
        }

        public void ClearPokemon()
        {
            
        }

        public void SelectMove(MoveSO move) => selectedMove = move;

        public void SelectTarget(Unit[] units) => selectedTargets = units;

        public void ClearMove() => selectedMove = null;
    }

    public enum ActionType
    {
        Move,
        Switch
    }
}