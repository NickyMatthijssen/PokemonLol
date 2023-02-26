using System;
using System.Collections;
using UnityEngine;

namespace BattleSystem2
{
    public class BattleSystem : MonoBehaviour
    {
        // Player
        // Opponent
        
        // BattleStationPrefab
        [SerializeField] private GameObject BattleStation;

        private bool isInProgress = false;
        
        private void Start()
        {
            InitializeBattle();
            
            StartCoroutine(BattleLoop());
        }

        private void InitializeBattle()
        {
            // Create battle stations for player and opponent.
            var station = Instantiate(BattleStation);

            // Setup units on battlestations.

            // Keep track which units are the players.

            // 

            isInProgress = true;
        }

        private IEnumerator BattleLoop()
        {
            while (isInProgress)
            {
                
            }

            yield return StartCoroutine(EndBattle());
        }

        private IEnumerator EndBattle()
        {
            // Play dialogue

            yield return new WaitForSeconds(2);
        }
    }

    public enum BattleType
    {
        Single,
        Double,
        Triple
    }

    public enum Weather
    {
        Sunny,
        Rain,
        Fog
    }
}