using UnityEngine;

public class AttackAction : IBattleAction
{
    public MoveSO move;

    public AttackAction(MoveSO move)
    {
        this.move = move;
        this.priority = 1;
    }

    public int priority { get; }

    public void Execute()
    {
        Debug.Log("Executea action");
    }
}
