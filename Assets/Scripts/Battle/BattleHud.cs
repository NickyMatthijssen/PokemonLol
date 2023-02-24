using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] public Pokemon pokemon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Slider healthSlider;

    void Update()
    {
        if (pokemon == null) return;

        nameText.text = pokemon.nickname;
        levelText.text = pokemon.level.ToString();
        healthSlider.value = pokemon.currentHp / pokemon.hp;
    }
}
