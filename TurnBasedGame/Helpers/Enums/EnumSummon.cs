using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Mobs;
using TurnBasedGame.Main.Entities.Summons;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumSummon
    { 
        StoneGolem,
        MiniStoneGolem,
        UndeadSpearsman,
        UndeadSwordsman,
    }

    public static class SummonSelector
    {
        public static readonly Dictionary<EnumSummon, Func<Unit>> Selector = new Dictionary<EnumSummon, Func<Unit>>
        {
            { EnumSummon.MiniStoneGolem, () => new MiniStoneGolem() },
            { EnumSummon.StoneGolem, () => new StoneGolem() },
            { EnumSummon.UndeadSpearsman, () => new UndeadSpearsman() },
            { EnumSummon.UndeadSwordsman, () => new UndeadSwordsman() }
        };
    }
}
