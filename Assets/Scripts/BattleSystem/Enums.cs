namespace BattleSystem2
{
    public enum NonVolatileStatus
    {
        Poison,
        BadlyPoisoned,
        Burn,
        Paralyzed,
        Sleep,
        Freeze,
    }

    public enum VolatileStatus
    {
        Bound,
        CantEscape,
        Confusion,
        AbilityChange,
        AbilitySuppression,
        Curse,
        Drowsy,
        Embargo,
        Encore,
        Flinch,
        HealBlock,
        Identified,
        Infatuation,
        Nightmare,
        PerishSong,
        Seeded,
        Taunt,
        Telekinesis,
        Torment,
        TypeChange,
        Splinters,
        PowerBoost,
        PowerDrop,
        GuardBoost,
        GuardDrop
    }

    public enum VolatileBattleStatus
    {
        AquaRing,
        Bracing,
        ChargingTurn,
        CenterOfAttention,
        DefenceCurl,
        GettingPumped,
        Rooting,
        MagicCoat,
        MagneticLevitation,
        Mimic,
        Minimize,
        PowerTrick,
        Protection,
        Rampage,
        Recharging,
        SemiInvulnerableTurn,
        Substitute,
        TakingAim,
        Transformed,
        Fixated,
        Primed,
        Obscured
    }

    public enum Type
    {
        Normal,
        Fire,
        Fighting,
        Water,
        Flying,
        Grass,
        Poison,
        Electric,
        Ground,
        Psychic,
        Rock,
        Ice,
        Bug,
        Dragon,
        Ghost,
        Dark,
        Steel,
        Fairy
    }

    public class TypeMap
    {
        private float[][] _map = new[]
        {
            //                  NOR,  FIR,  WAT,  ELE,  GRA,  ICE,  FIG,  POI,  GRO,  FLY,  PSY,  BUG,  ROC,   GHO,  DRA,  DAR,  STE,  FAI
            /** NOR **/ new []{ 1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0.5f,  0,    1,    1,    0.5f, 1 },
            /** FIR **/ new []{ 1,    0.5f, 0.5f, 1,    2,    2,    1,    1,    1,    1,    1,    2,    0.5f,  1,    0.5f, 1,    2,    1 },
            /** WAT **/ new []{ 1,    2,    0.5f, 1,    0.5f, 1,    1,    1,    2,    1,    1,    1,    2,     1,    0.5f, 1,    1,    1},
            /** ELE **/ new []{ 1,    1,    2,    0.5f, 0.5f, 1,    1,    1,    0,    2,    1,    1,    1,     1,    0.5f, 1,    1,    1 },
            /** GRA **/ new []{ 1,    0.5f, 2,    1,    0.5f, 1,    1,    0.5f, 2,    0.5f, 1,    0.5f, 2,     1,    0.5f, 1,    0.5f, 1 },
            /** ICE **/ new []{ 1,    0.5f, 0.5f, 1,    2,    0.5f, 1,    1,    2,    2,    1,    1,    1,     1,    2,    1,    0.5f, 1 },
            /** FIG **/ new []{ 2,    1,    1,    1,    1,    2,    1,    0.5f, 0,    0.5f, 0.5f, 0.5f, 2,     0,    1,    2,    2,    0.5f },
            /** POI **/ new []{ 1,    1,    1,    1,    2,    1,    1,    0.5f, 0.5f, 1,    1,    1,    0.5f,  0.5f, 1,    1,    0,    2 },
            /** GRO **/ new []{ 1,    2,    1,    2,    0.5f, 1,    1,    2,    1,    0,    1,    0.5f, 2,     1,    1,    1,    2,    1 },
            /** FLY **/ new []{ 1,    1,    1,    0.5f, 2,    1,    2,    1,    1,    1,    1,    2,    0.5f,  1,    1,    1,    0.5f, 1 },
            /** PSY **/ new []{ 1,    1,    1,    1,    1,    1,    2,    2,    1,    1,    0.5f, 1,    1,     1,    1,    0,    0.5f, 1 },
            /** BUG **/ new []{ 1,    2,    1,    1,    2,    1,    0.5f, 0.5f, 1,    0.5f, 2,    1,    1,     0.5f, 1,    2,    0.5f, 0.5f },
            /** ROC **/ new []{ 1,    2,    1,    1,    1,    2,    0.5f, 1,    0.5f, 2,    1,    2,    1,     1,    1,    1,    0.5f, 1 },
            /** GHO **/ new []{ 0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    2,    1,    1,     2,    1,    0.5f, 1,    1 },
            /** DRA **/ new []{ 1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,     1,    2,    1,    0.5f, 0 },
            /** DAR **/ new []{ 1,    1,    1,    1,    1,    1,    0.5f, 1,    1,    1,    2,    1,    1,     2,    1,    0.5f, 1,    0.5f },
            /** STE **/ new []{ 1,    0.5f, 0.5f, 0.5f, 1,    2,    1,    1,    1,    1,    1,    1,    2,     1,    1,    1,    0.5f, 2 },
            /** FAI **/ new []{ 1,    0.5f, 1,    1,    1,    1,    2,    0.5f, 1,    1,    1,    1,    1,     1,    2,    2,    0.5f, 0 },
        };

        public float CheckMultiplier(Type? targetType, Type moveType)
        {
            if (targetType == null) return 1;

            return _map[(int) targetType][(int) moveType];
        }
        
        // public float CheckMultiplier(Type?[] targetType, Type moveType)
        // {
        //     if (targetType == null) return 1;
        //
        //     return _map[(int) targetType][(int) moveType];
        // }
    }
}