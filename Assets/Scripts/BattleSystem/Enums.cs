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
        // private float[][] _map = new[]
        // {
        //     //                       NOR, FIR, WAT, ELE, GRA, ICE, FIG, POI, GRO, FLY, PSY, BUG, ROC,    GHO,  DRA, DAR, STE,  FAI
        //     /** NORMAL   **/ new []{ 1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0.5f,   0,    1,   1,   0.5f, 1 },
        //     /** FIRE     **/ new []{ 1,   0.5f,0.5f,1,   2,   2,   1,   1,   1,   1,   1,   2,   0.5f,   1,    0.5f,1,   2,    1 },
        //     /** WATER    **/ new []{ 1,   2 },
        //     /** ELECTRIC **/ new []{ 1,   1 },
        //     /** GRASS    **/ new []{ 1,   0.5f },
        //     /** ICE      **/ new []{ 1,   0.5f },
        //     /** FIGHTING **/ new []{ 2,   1 },
        //     /** POISON   **/ new []{ 1,   1 },
        //     /** GROUND   **/ new []{ 1,   2 },
        //     /** FLYING   **/ new []{ 1,   1 },
        //     /** PSYCHIC  **/ new []{ 1,   1 },
        //     /** BUG      **/ new []{ 1,   2 },
        //     /** ROCK     **/ new []{ 1,   2 },
        //     /** GHOST    **/ new []{ 0,   1 },
        //     /** DRAGON   **/ new []{ 1,   1 },
        //     /** DARK     **/ new []{ 1,   1 },
        //     /** STEEL    **/ new []{ 1,   0.5f },
        //     /** FAIRY    **/ new []{ 1,   0.5f },
        // };
    }
}