using UnityEngine;

public interface IBattleAction
{
    public int priority { get; }
    
    public void Execute();
}
