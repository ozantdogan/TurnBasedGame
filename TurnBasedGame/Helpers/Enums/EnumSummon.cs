using TurnBasedGame.Main.Entities.Base;
using TurnBasedGame.Main.Entities.Summons;

namespace TurnBasedGame.Main.Helpers.Enums
{
    public enum EnumSummon
    { 
        StoneGolem,
        SkeletonUnit
    }

    public static class SummonSelector
    {
        public static readonly Dictionary<EnumSummon, Func<Unit>> Selector = new Dictionary<EnumSummon, Func<Unit>>
        {
            { EnumSummon.StoneGolem, () => new StoneGolem() }
        };
    }
}
