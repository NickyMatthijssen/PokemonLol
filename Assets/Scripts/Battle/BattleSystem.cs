using System.Collections;
using UnityEngine;

public enum BattleState
{
    MoveSelection,
    Combat,
    Won,
    Lost
}

public enum Weather
{
    Rain,
    Sunny,
    Fog
}

// TODO::

// Rewrite system a bit: 
// Need to have a check on weather.
// Save previous used move of both pokemon
// Add buffs and debuffs to unit.
// Create AI for trainer.
// Add way to compare moves, abilities, effects, items, etc. in different calculations.
// Add way to switch pokemon.

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    private BattleState state;

    [SerializeField] public Pokemon player;
    [SerializeField] public Pokemon opponent;

    [SerializeField] private BattleDialogueBox dialogue;

    [SerializeField] private BattleHud playerHud;
    [SerializeField] private BattleHud opponentHud;

    private MoveSO playerMove;
    private MoveSO opponentMove;

    [SerializeField] public Pokemon[] playerPokemonList;
    [SerializeField] public Pokemon[] opponentPokemonList;

    public GameObject playerStation;
    public GameObject opponentStation;

    public MoveSelection moveSelection;

    public Unit unit;

    public Weather? weather;

    void Awake()
    {
        SetupBattle();
    }

    void Update()
    {
        switch (state)
        {
            case BattleState.Combat:
                Combat();
                break;
            case BattleState.Won:
                Won();
                break;
            case BattleState.Lost:
                Lost();
                break;
            case BattleState.MoveSelection:
            default:
                MoveSelection();
                break;
        }
    }

    private void Combat()
    {
        dialogue.gameObject.SetActive(true);
    }

    private void Won()
    {
        
    }

    private void Lost()
    {
        
    }

    private void MoveSelection()
    {
        // show battle ui.
        dialogue.gameObject.SetActive(false);
    }

    private void SetupBattle()
    {
        player = playerPokemonList[0];
        opponent = opponentPokemonList[0];

        var playerUnit = Instantiate(unit, playerStation.transform);
        playerUnit.Init(player);
        var opponentUnit = Instantiate(unit, opponentStation.transform);
        opponentUnit.Init(opponent);

        playerHud.pokemon = player;
        opponentHud.pokemon = opponent;
        
        moveSelection.SetMoves(player.moves);
    }
    
    public void MoveLogic(MoveSO move)
    {
        state = BattleState.Combat;

        playerMove = move;
        // TODO:: Create trainer AI to pick move.
        opponentMove = move;

        StartCoroutine(MoveLogic_Suspended());
    }

    public IEnumerator MoveLogic_Suspended()
    {
        if (playerMove.speedPriority > opponentMove.speedPriority)
        {
            yield return PlayerMove();
            yield return OpponentMove();
            yield break;
        }

        if (opponentMove.speedPriority > playerMove.speedPriority)
        {
            yield return OpponentMove();
            yield return PlayerMove();
            yield break;
        }

        if (player.speed > opponent.speed)
        {
            yield return PlayerMove();
            yield return OpponentMove();
        }
        else
        {
            yield return OpponentMove();
            yield return PlayerMove();
        }

        state = BattleState.MoveSelection;
    }

    public IEnumerator PlayerMove()
    {
        dialogue.SetText($"{player.nickname} is using the move {playerMove.moveName} on {opponent.nickname}");
        
        yield return new WaitForSeconds(1);
        
        opponent.currentHp = Mathf.Max(opponent.currentHp - CalculateDamage(playerMove, player, opponent), 0);
    }

    public IEnumerator OpponentMove()
    {
        dialogue.SetText($"{opponent.nickname} is using the move {opponentMove.moveName} on {player.nickname}");
        
        yield return new WaitForSeconds(1);
        
        player.currentHp = Mathf.Max(player.currentHp - CalculateDamage(opponentMove, opponent, player), 0);
    }

    private int CalculateDamage(MoveSO move, Pokemon attacker, Pokemon target)
    {
        var A = attacker.attack;
        var D = target.defence;
        var STAB = 1;
        
        var critical = 1;
        
        var part1 = 2 * attacker.level * critical / 5 + 2;
        var part2 = part1 * move.power * A / D / 50 + 2;

        var part3 = Mathf.FloorToInt(part2 * (Random.Range(0.85f, 1)));

        return part3;
    }
}