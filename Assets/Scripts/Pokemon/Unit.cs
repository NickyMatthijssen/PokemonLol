using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Pokemon _pokemon;

    public Pokemon Pokemon
    {
        get { return _pokemon; }
    }

    public void Init(Pokemon pokemon)
    {
        _pokemon = pokemon;
        _pokemon.Init();
        Instantiate(_pokemon.Species.Model, transform);
    }
}
