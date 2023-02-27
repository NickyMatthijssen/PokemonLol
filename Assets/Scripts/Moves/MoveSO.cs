using System;
using System.Collections.Generic;
using System.Linq;
using BattleSystem2;
using UnityEngine;
using Type = BattleSystem2.Type;

namespace Moves
{
    [Serializable]
    [CreateAssetMenu(fileName = "MoveSO", menuName = "Pokemon/Move", order = 0)]
    public class MoveSO : ScriptableObject
    {
        [SerializeField] private MoveKeys id;
        public MoveKeys Id => id;
        
        [SerializeField] private string moveName;
        public string MoveName => moveName;

        [SerializeField] private int power;
        public int Power => power;
        
        [SerializeField] private float accuracy;
        public float Accuracy => accuracy;

        [SerializeField] private Type type;
        public Type Type => type;

        [SerializeField] private float baseCriticalHitRate;
        public float BaseCriticalHitRate => baseCriticalHitRate;

        [SerializeField] private int basePowerPoints;
        public int BasePowerPoints => basePowerPoints;
        
        [SerializeField] private MoveTag[] tags;
        public MoveTag[] Tags => tags;

        [SerializeField] private MoveCategory category;
        public MoveCategory Category => category;

        [SerializeField] private int speedPriority;
        public int SpeedPriority => speedPriority;

        [SerializeField] private MoveTarget target;
        public MoveTarget Target => target;
    }

    public enum MoveTag
    {
        MakesContact,
        IsSoundType,
        IsPunchMove,
        IsBitingMove,
        IsSnatchable,
        IsSlicingMove,
        IsBulletType,
        IsWindMove,
        IsPowderMove,
        CallableByMetronome,
        CallableByMirrorMove,
        IsAffectedByGravity,
        ReflectedByMagicCoat,
        BlockedByProtect,
        DefrostsOnUse
    }

    public enum MoveCategory
    {
        Physical,
        Special,
        Other
    }

    public enum MoveTarget
    {
        Self,
        SelfOrAlly,
        AllAdjacentFoes,
        Foe,
    }
}