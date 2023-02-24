using System.Collections;
using System.Collections.Generic;
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