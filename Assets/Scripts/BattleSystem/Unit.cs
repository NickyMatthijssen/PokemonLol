using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pokemon;

namespace BattleSystem2
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private Pokemon.Pokemon pokemon;
        public Pokemon.Pokemon Pokemon => pokemon;
        
        [SerializeField] private NonVolatileStatus status;
        public NonVolatileStatus Status => status;

        [SerializeField] private VolatileStatus[] volatileStatuesList;
        public VolatileStatus[] VolatileStatusList => volatileStatuesList;

        [SerializeField] private VolatileBattleStatus[] volatileBattleStatusList;
        public VolatileBattleStatus[] VolatileBattleStatusList => volatileBattleStatusList;

        [SerializeField] private bool belongsToPlayer;
        public bool BelongsToPlayer => belongsToPlayer;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}