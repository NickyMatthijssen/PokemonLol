    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using BattleSystem;
    using Monsters;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    namespace BattleSystem2
{
    public class BattleSystem : MonoBehaviour
    {
        [SerializeField] private BattleState state;
        public BattleState State => state;

        private IList<Unit> _units = new List<Unit>();
        public IList<Unit> Units => _units;
        public IList<Unit> PlayerUnits => _units.Where(u => u.BelongsToPlayer).ToList();
        public IList<Unit> OpponentUnits => _units.Where(u => !u.BelongsToPlayer).ToList();

        private IList<Unit> _switchedOutUnits = new List<Unit>();

        [SerializeField] private Unit currentUnit;
        public Unit CurrentUnit => currentUnit;

        [Header("Station Components")]
        [SerializeField] private GameObject playerStation;
        [SerializeField] private GameObject opponentStation;

        [Header("HUD Components")]
        [SerializeField] private GameObject playerHudPosition;
        [SerializeField] private GameObject opponentHudPosition;
        [SerializeField] private PokemonHud hudPrefab;
        [SerializeField] private UiStateManager uiManager;

        [SerializeField] private Party playerParty;
        public Party PlayerParty => playerParty;
        [SerializeField] private Party opponentParty;

        [SerializeField] private DialogueManager dialogueManager;

        [SerializeField] private Weather weather = Weather.Clear;
        public Weather Weather => weather;

        [SerializeField] private BattleType _battleType;
        
        private void Start()
        {
            state = BattleState.Initializing;
            
            InitializeBattle();
            
            StartCoroutine(BattleLoop());
        }

        private void InitializeBattle()
        {
            SetupStation(playerParty, true);
            SetupStation(opponentParty, false);

            currentUnit = PlayerUnits.First();
        }

        private IEnumerator BattleLoop()
        {
            state = BattleState.MoveSelection;

            while (state != BattleState.Finished)
            {
                yield return new WaitForFixedUpdate();
                
                yield return ActionSelection();
                
                yield return WaitForOpponentActions();
                
                yield return HandleCombat();
                
                yield return AfterTurn();
            }

            yield return EndBattle();
        }

        private IEnumerator ActionSelection()
        {
            foreach (var unit in PlayerUnits)
            {
                currentUnit = unit;
                unit.Targets.Add(OpponentUnits.First());
                
                while (unit.SelectedMoved == null)
                {
                    yield return new WaitForFixedUpdate();
                }
            }

            state = BattleState.Waiting;

            yield return null;
        }

        private IEnumerator WaitForOpponentActions()
        {
            foreach (var unit in OpponentUnits)
            {
                while (unit.SelectedMoved == null)
                {
                    unit.SelectMove(unit.Pokemon.Moves[0]);
                    unit.Targets.Add(PlayerUnits.First());
                }
            }
            
            yield return null;
        }

        private IEnumerator HandleCombat()
        {
            state = BattleState.Combat;
            
            var orderedUnits = _units.OrderBy(u => u, new Orderer()).ToList();

            foreach (var unit in orderedUnits)
            {
                if (unit.SelectedMoved == null) continue;

                yield return dialogueManager.PlayDialogue($"{unit.Pokemon.Nickname} used {unit.SelectedMoved.MoveName}");
                
                // Accuracy check.
                
                // if accuracy check fails show dialogue and continue loop.

                foreach (var target in unit.Targets)
                {
                    var damageCalculator = new DamageCalculator(unit.SelectedMoved, unit, target, this);
                    var damage = damageCalculator.Calculate();
                    Debug.Log($"{target.Pokemon.Nickname} {damage.ToString()}");
                    target.Pokemon.TakeDamage(damage);

                    if (damageCalculator.IsCritical)
                    {
                        yield return dialogueManager.PlayDialogue("It's a critical hit!");
                    }
                    
                    // Add super effective, not very effective or target was unaffected.
                }

                // IF pokemon fainted handle switch.
                // Loop until pokemon was selected
                // In loop set action state to pokemonn selection.
                // If pokemon selected break loop and continue
                // while ()
                // {
                if (unit.Targets.First().Pokemon.CurrentHitPoints < 1)
                {
                    SwitchPokemon(unit.Targets.First().Pokemon, opponentParty.AvailablePokemon.First());
                }
                
                
                //     yield return new WaitForFixedUpdate();
                // }

                // Handle move effects.

            }

            state = BattleState.MoveSelection;
        }

        private IEnumerator AfterTurn()
        {
            foreach (var unit in _units)
            {
                unit.PreviousMove = unit.SelectedMoved;
                unit.Targets.Clear();
                unit.ClearMove();
            }

            currentUnit = PlayerUnits.First();

            if (playerParty.IsWhitedOut || opponentParty.IsWhitedOut)
            {
                state = BattleState.Finished;
                yield break;
            }

            state = BattleState.MoveSelection;
            
            yield return null;
        }

        private IEnumerator EndBattle()
        {
            if (playerParty.IsWhitedOut)
            {
                yield return dialogueManager.PlayDialogue("You lost the battle!");
            }
            else
            {
                yield return dialogueManager.PlayDialogue("You won the battle!");
            }

            yield return new WaitForSeconds(2);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void SetupStation(Party party, bool isPlayer)
        {
            var station = isPlayer ? playerStation : opponentStation;
            
            for (int i = 1; i <= (int) _battleType; i++)
            {
                var pokemon = party.AvailablePokemon[i - 1];
                
                if (pokemon == null) break;

                var hudPosition = isPlayer ? playerHudPosition : opponentHudPosition;
                var hud = Instantiate(hudPrefab, hudPosition.transform);
                hud.Initialize(pokemon);
                
                // TODO:: Could use more optimalization...
                var unitObject = new GameObject();
                var unit = unitObject.AddComponent<Unit>();
                unit.Initialize(pokemon, isPlayer, hud, this);
                unitObject.transform.position = station.transform.position + Vector3.forward * 10 * (i - 1);
                unitObject.transform.SetParent(station.transform);
                unitObject.transform.localRotation = Quaternion.identity;
                unitObject.transform.localScale = new Vector3(1, 1, 1);
                
                _units.Add(unit);
            }
        }
        
        private void SetupStations(Pokemon pokemon, bool isPlayer)
        {
            var station = isPlayer ? playerStation : opponentStation;

            var hudPosition = isPlayer ? playerHudPosition : opponentHudPosition;
            var hud = Instantiate(hudPrefab, hudPosition.transform);
            hud.Initialize(pokemon);
            
            var unitObject = new GameObject();
            var unit = unitObject.AddComponent<Unit>();
            unit.Initialize(pokemon, isPlayer, hud, this);
            unit.transform.parent = station.transform;
            unit.transform.position = Vector3.zero;
            unit.transform.localScale = new Vector3(1, 1, 1);

           

            _units.Add(unit);
        }

        private void SwitchPokemon(Pokemon switchingOut, Pokemon switchingIn)
        {
            var switchingOutUnit = _units.First(u => u.Pokemon == switchingOut);

            switchingOutUnit.SetupPokemon(switchingIn);
        }

        public void SwitchPokemon(Pokemon pokemon)
        {
            currentUnit.SetupPokemon(pokemon);
        }
    }

    internal class Orderer : IComparer<Unit>
    {
        public int Compare(Unit x, Unit y)
        {
            // Check if move has speed priority.
            if (x.SelectedMoved.SpeedPriority > y.SelectedMoved.SpeedPriority)
            {
                return 1;
            } 
            if (x.SelectedMoved.SpeedPriority < y.SelectedMoved.SpeedPriority)
            {
                return 0;
            }
            
            // Check speed.
            if (x.Pokemon.Speed > y.Pokemon.Speed)
            {
                return 1;
            }

            if (x.Pokemon.Speed < y.Pokemon.Speed)
            {
                return 0;
            }

            // If both equal, check with rng.
            return 1;
        }
    }

    public enum BattleState
    {
        Initializing,
        MoveSelection,
        Waiting,
        Combat,
        Fainted,
        Finished
    }

    public enum BattleType
    {
        Single = 1,
        Double = 2
    }

    public enum Weather
    {
        Clear,
        Sunny,
        Rain,
        Fog
    }
}