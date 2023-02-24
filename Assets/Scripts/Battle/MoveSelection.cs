using UnityEngine;
using UnityEngine.UI;

public class MoveSelection : MonoBehaviour
{
    public Button buttonPrefab;
    public BattleSystem battleSystem;
    
    public void SetMoves(MoveSO[] moves)
    {
        var children = GetComponentsInChildren<Button>();
        foreach (var child in children)
        {
            child.onClick.RemoveAllListeners();
            Destroy(child.gameObject);
        }
        
        var index = 0;
        foreach (var move in moves)
        {
            var button = Instantiate(buttonPrefab, transform);
            button.GetComponentInChildren<Text>().text = move.moveName;
            button.GetComponent<RectTransform>().anchoredPosition = Vector2.up * index * 50;
            button.onClick.AddListener(() => battleSystem.MoveLogic(move));
            index++;
        }
    }
}
